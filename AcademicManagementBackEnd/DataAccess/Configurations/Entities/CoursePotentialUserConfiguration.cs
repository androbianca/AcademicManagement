using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{

    public class CoursePotentialUserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<PotentialUserCourse>
    {
        public void Configure(EntityTypeBuilder<PotentialUserCourse> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.PotentialUserId });

            builder.HasOne(x => x.Course)
                .WithMany(y => y.PotentialUsers)
                .HasForeignKey(y => y.CourseId);

            builder.HasOne(x => x.PotentialUser)
                .WithMany(y => y.Courses)
                .HasForeignKey(y => y.PotentialUserId);
        }
    }

}
