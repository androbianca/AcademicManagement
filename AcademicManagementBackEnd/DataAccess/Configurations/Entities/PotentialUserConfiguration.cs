using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PotentialUserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<PotentialUser>
    {
        public void Configure(EntityTypeBuilder<PotentialUser> builder)
        {      
            builder.Property(p => p.UserCode)
                .IsRequired();

            builder.Property(p => p.UserRoleId)
                .IsRequired();

        }
    }
}
