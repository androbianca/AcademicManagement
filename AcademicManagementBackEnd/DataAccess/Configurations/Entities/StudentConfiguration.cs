using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {       
         
            builder.HasOne(a => a.PotentialUser)
                .WithOne(b => b.Student)
                .HasForeignKey<Student>(c => c.PotentialUserId)
                .HasConstraintName("ForeignKey_Student_PotentialUser");

            builder.Property(p => p.UserCode)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.Email)
                .IsRequired();

        }
    }
}
