using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{

    public class ProfCourseConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<ProfCourse>
    {
        public void Configure(EntityTypeBuilder<ProfCourse> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.ProfId });

            builder.HasOne(x => x.Course)
                .WithMany(y => y.Profs)
                .HasForeignKey(y => y.CourseId);

            builder.HasOne(x => x.Professor)
                .WithMany(y => y.Courses)
                .HasForeignKey(y => y.ProfId);
        }
    }

}
