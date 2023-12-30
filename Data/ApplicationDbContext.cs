using Issue_tracker_webapp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Issue_tracker_webapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
    }
        public DbSet<Entities.AppUser> users { get; set; }
        public DbSet<Entities.Issue> issues { get; set; }
        public DbSet<Entities.Project> projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Project)
                .WithMany(p => p.issues)
                .HasForeignKey(i => i.projectID1)
                .OnDelete(DeleteBehavior.Cascade);  // Choose the appropriate delete behavior

            // Additional configurations if needed
        }
    }
}