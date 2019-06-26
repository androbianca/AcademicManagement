using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class FinalGradeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<FinalGrade>
    {
        public new void Configure(EntityTypeBuilder<FinalGrade> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CourseId)
                .IsRequired();

            builder.Property(p => p.StudentId)
            .IsRequired();

            builder.Property(p => p.Value)
            .IsRequired();
        }
    }
}
