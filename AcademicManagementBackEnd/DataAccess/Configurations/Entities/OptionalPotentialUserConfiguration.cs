using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{

    public class OptionalPotentialUserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<OptionalPotentialUser>
    {
        public void Configure(EntityTypeBuilder<OptionalPotentialUser> builder)
        {
            builder.HasKey(x => new { x.OptionalId, x.PotentialUserId });

            builder.HasOne(x => x.Optional)
                .WithMany(y => y.PotentialUsers)
                .HasForeignKey(y => y.PotentialUserId);

            builder.HasOne(x => x.PotentialUser)
                .WithMany(y => y.Optionals)
                .HasForeignKey(y => y.OptionalId);
        }
    }

}
