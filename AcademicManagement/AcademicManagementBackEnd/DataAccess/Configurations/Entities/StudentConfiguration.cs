using DataAccess.Configurations.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class StudentConfiguration : BaseUserConfiguration,IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {       
         
            builder.HasOne(a => a.PotentialUser)
                .WithOne(b => b.Student)
                .HasForeignKey<Student>(c => c.PotentialUserId)
                .HasConstraintName("ForeignKey_Student_PotentialUser");

            builder.HasOne(x => x.Group)
                .WithMany(y => y.Students)
                .HasForeignKey(z => z.GroupId)
                .HasConstraintName("ForeignKey_Student_Group");

        }
    }
}
