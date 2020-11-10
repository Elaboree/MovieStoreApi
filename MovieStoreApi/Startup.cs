using MediatR;
using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieStoreApi.Data.Context;
using MovieStoreApi.Data.Repository.v1;
using MovieStoreApi.Domain;
using MovieStoreApi.MessageConsumer.Consumer;
using MovieStoreApi.MessageConsumer.Options;
using MovieStoreApi.MessageProducer.Options;
using MovieStoreApi.MessageProducer.Sender;
using MovieStoreApi.Middlewares;
using MovieStoreApi.Service;
using MovieStoreApi.Service.Extensions;
using MovieStoreApi.Service.MailServices;
using MovieStoreApi.Service.QueueServices;
using MovieStoreApi.Worker;
using MovieStoreApi.Worker.Options;
using FluentValidation;
using MovieStoreApi.Service.v1.Command;
using MovieStoreApi.Validators.v1;
using MovieStoreApi.Service.v1.Query;
using MovieStoreApi.Service.Models;
using FluentValidation.AspNetCore;

namespace MovieStoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<RabbitMqProducerConfiguration>(Configuration.GetSection("RabbitMq"));

            services.Configure<RabbitMqConsumerConfiguration>(Configuration.GetSection("RabbitMq"));

            services.Configure<WorkerOptions>(Configuration.GetSection("WorkerOptions"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MovieStore Api",
                    Description = "A simple API to lookup movies",
                    Contact = new OpenApiContact
                    {
                        Name = "Okan Yilmaz",
                        Email = "oyilmaz5@outlook.com",
                        Url = new Uri("https://www.linkedin.com/in/okanyilmazz/")
                    }
                });
            });

            services.AddSingleton<IMovieWorker, MovieWorker>();

            services.AddHttpContextAccessor();

            services.AddMvc().AddFluentValidation();

            services.AddDbContext<MovieStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection"), x => x.MigrationsAssembly("MovieStoreApi.Data")));

            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<MovieStoreContext>()
                .AddDefaultTokenProviders();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // JWT authentication Aayarlamasý
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<IValidator<AddMovieCriticCommand>, AddMovieCriticCommandValidator>();
            services.AddTransient<IValidator<AuthenticateQuery>, AuthenticateQueryValidator>();
            services.AddTransient<IValidator<UserRegisterModel>, UserRegisterModelValidator>();

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ICriticRepository, CriticRepository>();
            services.AddTransient<IMailService, MailService>();

            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(AppSettings).Assembly, typeof(MovieConsumerService).Assembly);
            services.AddTransient<IMovieTransportService, MovieTransportService>();
            services.AddTransient<IMovieSender, MovieSender>();

            services.AddHandlers();
            services.AddHostedService<MovieWorkerService>();
            services.AddHostedService<MovieConsumerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieStore Api V1");
                c.RoutePrefix = "swagger/v1";
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
