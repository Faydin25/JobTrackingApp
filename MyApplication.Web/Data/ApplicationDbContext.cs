using Microsoft.EntityFrameworkCore;
using MyApplication.Web.Models;

namespace MyApplication.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<MyApplication.Web.Models.Task>? Tasks { get; set; }  // Task modelini DbSet olarak ekliyoruz

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User ile Task arasındaki ilişkiyi kuruyoruz
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
    }
}
