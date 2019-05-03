using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.Entities
{
    public class ProfessorConfiguration : BaseUserConfiguration, IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasOne(a => a.PotentialUser)
                .WithOne(b => b.Professor)
                .HasForeignKey<Professor>(c => c.PotentialUserId)
                .HasConstraintName("ForeignKey_Professor_PotentialUser");
        }
    }
}
