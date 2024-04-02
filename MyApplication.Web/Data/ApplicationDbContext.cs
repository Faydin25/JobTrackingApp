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
    }
}
