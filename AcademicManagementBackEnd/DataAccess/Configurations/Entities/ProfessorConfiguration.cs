using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class ProfessorConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasOne(a => a.PotentialUser)
                .WithOne(b => b.Professor)
                .HasForeignKey<Professor>(c => c.PotentialUserId)
                .HasConstraintName("ForeignKey_Professor_PotentialUser");

            builder.Property(p => p.UserCode)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(40);


        }
    }
}
