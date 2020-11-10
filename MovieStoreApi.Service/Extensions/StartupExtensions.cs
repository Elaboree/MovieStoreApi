using MediatR;
using AutoMapper;
using MovieStoreApi.Domain;
using MovieStoreApi.Service.v1.Command;
using MovieStoreApi.Service.v1.Query;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreApi.Data.Repository.v1;

namespace MovieStoreApi.Service.Extensions
{
    public static class StartupExtensions
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StartupExtensions));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IRequestHandler<AddMovieByQueueCommand>, AddMovieByQueueCommandHandler>();
            services.AddTransient<IRequestHandler<AddMovieCriticCommand>, AddMovieCriticCommandHandler>();
            services.AddTransient<IRequestHandler<AuthenticateQuery, AuthenticateQueryResponse>, AuthenticateQueryHandler>();
            services.AddTransient<IRequestHandler<GetMoviesQuery, GetMoviesQueryResponse>, GetMoviesQueryHandler>();
            services.AddTransient<IRequestHandler<GetMovieQuery, GetMovieQueryResponse>, GetMovieQueryHandler>();
            services.AddTransient<IRequestHandler<SendRecommendationQuery>, SendRecommendationQueryHandler>();
            services.AddTransient<IRequestHandler<UserRegisterCommand>, UserRegisterCommandHandler>();
        }
    }
}
