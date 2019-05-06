using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class GradeConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasOne(x => x.Student)
                .WithMany(y => y.Grades)
                .HasForeignKey(z => z.StudentId)
                .HasConstraintName("ForeignKey_Student_Grade");

            builder.HasOne(x => x.Professor)
                .WithMany(y => y.Grades)
                .HasForeignKey(z => z.ProfId)
                .HasConstraintName("ForeignKey_Prof_Grade");

            builder.HasOne(x => x.Course)
                .WithMany(y => y.Grades)
                .HasForeignKey(z => z.CourseId)
                .HasConstraintName("ForeignKey_Course_Grade");


        }
    }
}
