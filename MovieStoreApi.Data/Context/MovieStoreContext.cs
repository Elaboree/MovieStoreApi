using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Data.Configurations;
using MovieStoreApi.Domain;

namespace MovieStoreApi.Data.Context
{
    public class MovieStoreContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Critic> Critics { get; set; }

        public MovieStoreContext(DbContextOptions<MovieStoreContext> dbContext) : base(dbContext) 
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new CriticConfiguration());

            builder
                .ApplyConfiguration(new MovieConfiguration());

            builder
                .ApplyConfiguration(new UserConfiguration());
        }
    }
}