using Diplom.Gamification.Domain;
using Diplom.Gamification.Persistence.Configuration.Tables;
using Diplom.Gamification.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Gamification.Persistence
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<LearningProgress> LearningProgress { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TablesConfiguration.Configure(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
        
    }
}
