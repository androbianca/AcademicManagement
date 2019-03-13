using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {       
         
            builder.HasOne(a => a.PotentialUser)
                .WithOne(b => b.User)
                .HasForeignKey<User>(c => c.PotentialUserId)
                .HasConstraintName("ForeignKey_User_PotentialUser");

            builder.Property(p => p.UserCode)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.Email)
                .IsRequired();

        }
    }
}
