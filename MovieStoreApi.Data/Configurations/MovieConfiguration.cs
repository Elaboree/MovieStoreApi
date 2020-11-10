using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStoreApi.Domain;

namespace MovieStoreApi.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
             .HasKey(a => a.Id);

            builder
                .Property(m => m.Id).UseIdentityColumn();

            builder
                .Property(m => m.Title)
                .IsRequired();

            builder
                 .Property(m => m.OverView);

            builder
                 .Property(m => m.VoteAverage)
                 .HasColumnType("decimal(2,1)");

            builder
                .ToTable("Movies");

        }
    }
}
