using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class ProfRoleConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<ProfRole>
    {
        public void Configure(EntityTypeBuilder<ProfRole> builder)
        {
            builder.HasKey(x => new { x.ProfId, x.RoleId });

            builder.HasOne(x => x.Professor)
                .WithMany(y => y.Roles)
                .HasForeignKey(y => y.ProfId);

            builder.HasOne(x => x.Role)
                .WithMany(y => y.Profs)
                .HasForeignKey(y => y.RoleId);
        }
    }
}
