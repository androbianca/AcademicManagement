using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class AccountConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(p => p.UserCode)
                .IsRequired();

            builder.HasOne(a => a.PotentialUser)
                .WithOne(b => b.Account)
                .HasForeignKey<Account>(c => c.PotentialUserId)
                .HasConstraintName("ForeignKey_Account_PotentialUser");

        }
    }
}


