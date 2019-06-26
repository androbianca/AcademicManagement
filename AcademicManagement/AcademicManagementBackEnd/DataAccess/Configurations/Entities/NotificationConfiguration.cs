using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class NotificationConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(20);


            builder.Property(x => x.Body)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(x => x.Time)
                .IsRequired();

            builder.Property(x => x.IsRead)
            .IsRequired();

        }
    }
}





