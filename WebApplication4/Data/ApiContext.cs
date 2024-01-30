using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Design;
namespace WebApplication4.Data
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }


        public DbSet<UserInfo> Users { get; set; } = null!;
        public DbSet<LogInfo> Logs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}
