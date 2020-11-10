using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStoreApi.Domain;

namespace MovieStoreApi.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    { 
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
             .HasKey(a => a.Id);

            builder
                .Property(m => m.Id).UseIdentityColumn();

            builder
                .ToTable("Users");

        }
    }
}
