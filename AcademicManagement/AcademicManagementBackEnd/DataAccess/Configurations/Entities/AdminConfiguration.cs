using DataAccess.Configurations.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AdminConfiguration : BaseUserConfiguration,IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {       
         
            builder.HasOne(a => a.PotentialUser)
                .WithOne(b => b.Admin)
                .HasForeignKey<Admin>(c => c.PotentialUserId)
                .HasConstraintName("ForeignKey_Admin_PotentialUser");


        }
    }
}
