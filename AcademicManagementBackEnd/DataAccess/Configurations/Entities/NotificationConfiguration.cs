using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
   public class NotificationConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasOne(a => a.Account)
                .WithMany(b => b.Notifications)
                .HasForeignKey(c => c.AccountId);
        }
    }
}





