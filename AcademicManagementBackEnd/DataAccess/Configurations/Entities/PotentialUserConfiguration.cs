using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PotentialUserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<PotentialUser>
    {
        public void Configure(EntityTypeBuilder<PotentialUser> builder)
        {      
            builder.Property(p => p.UserCode)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.Year)
                .HasMaxLength(1);

            builder.Property(p => p.Semester)
                .HasMaxLength(1);

            builder.Property(p => p.Group)
                .HasMaxLength(2);

        }
    }
}
