using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public abstract class BaseUserConfiguration : BaseEntityConfiguration
    {
        public void Configure<T>(EntityTypeBuilder<T> builder)
            where T : BaseUser
        {
            builder.Property(p => p.UserCode)
                    .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.Email)
                .IsRequired();

        }
    }
}
