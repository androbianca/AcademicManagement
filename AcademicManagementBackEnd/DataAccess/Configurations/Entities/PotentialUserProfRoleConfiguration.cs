using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class PotentialUserProfRoleConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<PotentialUserProfRole>
    {
        public void Configure(EntityTypeBuilder<PotentialUserProfRole> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.PotentialUserId });

            builder.HasOne(x => x.ProfRole)
                .WithMany(y => y.PotentialUsers)
                .HasForeignKey(y => y.RoleId);

            builder.HasOne(x => x.PotentialUser)
                .WithMany(y => y.Roles)
                .HasForeignKey(y => y.PotentialUserId);
        }
    }
}
