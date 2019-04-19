using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{

    public class StudCourseConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<StudCourse>
    {
        public void Configure(EntityTypeBuilder<StudCourse> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.StudId });

            builder.HasOne(x => x.Course)
                .WithMany(y => y.Studs)
                .HasForeignKey(y => y.CourseId);

            builder.HasOne(x => x.Student)
                .WithMany(y => y.Courses)
                .HasForeignKey(y => y.StudId);
        }
    }

}
