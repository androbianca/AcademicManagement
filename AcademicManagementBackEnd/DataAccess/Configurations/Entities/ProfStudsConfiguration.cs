using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class ProfStudsConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<ProfStuds>
    {
        public void Configure(EntityTypeBuilder<ProfStuds> builder)
        {
            builder.Property(x => x.CourseId)
                .IsRequired();
            builder.Property(x => x.ProfId)
                .IsRequired();
            builder.Property(x => x.GroupId)
                .IsRequired();
        }
    }
}
