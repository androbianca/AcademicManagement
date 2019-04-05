using DataAccess.Configurations;
using DataAccess.Configurations.Entities;
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
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PotentialUser> PotentialUsersCourse { get; set; }

        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      
            modelBuilder.ApplyConfiguration(new PotentialUserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new OptionalPotentialUserConfiguration());
           // modelBuilder.ApplyConfiguration(new ProfessorConfiguration());

        }
    }
}
