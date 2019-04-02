using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{

    public class OptionalPotentialUserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<PUserOptionalCourse>
    {
        public void Configure(EntityTypeBuilder<PUserOptionalCourse> builder)
        {
            builder.HasKey(x => new { x.OptionalCourseId, x.PotentialUserId });

            builder.HasOne(x => x.OptionalCourse)
                .WithMany(y => y.PotentialUsers)
                .HasForeignKey(y => y.OptionalCourseId);

            builder.HasOne(x => x.PotentialUser)
                .WithMany(y => y.OptionalCourses)
                .HasForeignKey(y => y.PotentialUserId);
        }
    }

}
