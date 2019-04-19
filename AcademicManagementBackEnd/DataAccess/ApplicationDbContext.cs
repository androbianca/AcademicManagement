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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ProfCourse> ProfCourse { get; set; }
        public DbSet<StudCourse> StudCourse { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProfRole> ProfRole { get; set; }
        public DbSet<ProfGroup> ProfGroup { get; set; }
        public DbSet<ProfStuds> ProfStuds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                      
            modelBuilder.ApplyConfiguration(new PotentialUserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ProfCourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudCourseConfiguration());        
            modelBuilder.ApplyConfiguration(new GroupConfiguraton());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProfRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProfGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ProfStudsConfiguration());

        }
    }
}
