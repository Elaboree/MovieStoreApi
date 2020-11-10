using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStoreApi.Domain;

namespace MovieStoreApi.Data.Configurations
{
    public class CriticConfiguration : IEntityTypeConfiguration<Critic>
    {
        public void Configure(EntityTypeBuilder<Critic> builder)
        {
            builder
             .HasKey(a => a.Id);

            builder
                .Property(m => m.Id).UseIdentityColumn();

            builder
                .Property(m => m.Rating)
                .HasColumnType("decimal(2,1)")
                .IsRequired(true);

            builder
                .HasOne(m => m.Movie)
                .WithMany(a => a.Critics)
                .HasForeignKey(m => m.MovieId);

            builder
                .ToTable("Critics");

        }
    }
}
