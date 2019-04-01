using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{

    public class OptionalConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Optional>
        {
            public void Configure(EntityTypeBuilder<Optional> builder)
            {
                builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                builder.Property(p => p.Package)
                    .IsRequired()
                    .HasMaxLength(5);

            builder.Property(p => p.Year)
                    .IsRequired()
                    .HasMaxLength(1);

                builder.Property(p => p.Semester)
                    .IsRequired()
                    .HasMaxLength(1);

            }
        }
}
