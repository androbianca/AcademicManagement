using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class FeedbackConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Feedback>
    {
        public new void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(x => x.Body)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.HasOne(x => x.Professor)
                .WithMany(y => y.Feedback)
                .HasForeignKey(z => z.ProfessorId);

            builder.HasOne(x => x.Student)
                .WithMany(y => y.Feedback)
                .HasForeignKey(z => z.StudentId);
        }
    }
}
