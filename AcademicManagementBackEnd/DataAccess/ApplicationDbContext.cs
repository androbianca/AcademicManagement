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

        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PotentialUser> PotentialUsers { get; set; }
        public DbSet<PotentialUserCourse> PotentialUsersCourse { get; set; }
        public DbSet<ProfRole> ProfRoles{ get; set; }
        public DbSet<PotentialUserProfRole> PotentialUserProfRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      
            modelBuilder.ApplyConfiguration(new PotentialUserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new PotentialUserCourseConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new ProfRoleConfiguration());
            modelBuilder.ApplyConfiguration(new PotentialUserProfRoleConfiguration());

        }
    }
}
