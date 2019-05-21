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
        public DbSet<StudCourse> StudCourse { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProfRole> ProfRole { get; set; }
        public DbSet<ProfStuds> ProfStuds { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedback {get; set;}
        public DbSet<Post> Posts { get; set; }
        public DbSet<FileMetadata> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PotentialUserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudCourseConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguraton());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ProfRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProfStudsConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new FileMetadataConfiguration());



        }
    }
}
