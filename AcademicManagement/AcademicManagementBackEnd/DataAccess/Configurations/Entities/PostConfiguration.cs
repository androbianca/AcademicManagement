using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class PostConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Body)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.Time)
                   .IsRequired();
                   
            builder.HasOne(a => a.Account)
                .WithMany(b => b.Posts)
                .HasForeignKey(c => c.AccountId);
        }
    }
}
