using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class ProfGroupConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<ProfGroup>
    {
        public void Configure(EntityTypeBuilder<ProfGroup> builder)
        {
            builder.HasKey(x => new { x.ProfId, x.GroupId });

            builder.HasOne(x => x.Professor)
                .WithMany(y => y.Groups)
                .HasForeignKey(y => y.ProfId);

            builder.HasOne(x => x.Group)
                .WithMany(y => y.Profs)
                .HasForeignKey(y => y.GroupId);
        }
    }
}
