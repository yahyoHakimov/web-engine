using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication4.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<LogInfo> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship between UserInfo and LogInfo
            modelBuilder.Entity<LogInfo>()
                .HasOne(l => l.UserInfo)
                .WithMany(u => u.Logs)
                .HasForeignKey(l => l.UserInfoId);

            // (Optional) Configure cascading behavior, such as deleting logs when a user is deleted
            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.Logs)
                .WithOne(l => l.UserInfo)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
