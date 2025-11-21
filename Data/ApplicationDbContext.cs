using Microsoft.EntityFrameworkCore;
using FutureOfWork.Api.Models;

namespace FutureOfWork.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<WorkItem>().HasMany(w => w.Comments).WithOne(c => c.WorkItem).HasForeignKey(c => c.WorkItemId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
