using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PotentialUserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<PotentialUser>
    {
        public void Configure(EntityTypeBuilder<PotentialUser> builder)
        {
            builder.Property(p => p.Code)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(40);

        }
    }
}
