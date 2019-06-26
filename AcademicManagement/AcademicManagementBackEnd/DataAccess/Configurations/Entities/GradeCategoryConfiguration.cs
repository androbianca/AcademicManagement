using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    class GradeCategoryConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<GradeCategory>
    {
        public new void Configure(EntityTypeBuilder<GradeCategory> builder)
        {
            builder.HasOne(x => x.Course)
                .WithMany(y => y.Categories)
                .HasForeignKey(z => z.CourseId);
        }
    }
}
