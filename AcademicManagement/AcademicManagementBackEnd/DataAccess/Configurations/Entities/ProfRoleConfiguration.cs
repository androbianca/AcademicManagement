using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class ProfRoleConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<ProfRole>
    {
        public void Configure(EntityTypeBuilder<ProfRole> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
