using DataAccess.Configurations;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PotentialUser> PotentialUsers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
      
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      
            modelBuilder.ApplyConfiguration(new PotentialUserConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationConfiguration());

        }
    }
}
