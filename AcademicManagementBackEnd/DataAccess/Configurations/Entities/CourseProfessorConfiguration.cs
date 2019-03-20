using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class CourseProfessorConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<CourseProfessor>
    {
        public void Configure(EntityTypeBuilder<CourseProfessor> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.ProfessorId });

            builder.HasOne(x => x.Course)
                .WithMany(y => y.Professors)
                .HasForeignKey(y => y.ProfessorId);

            builder.HasOne(x => x.Professor)
                .WithMany(y => y.Courses)
                .HasForeignKey(y => y.CourseId);

        }
    }
}
