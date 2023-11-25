using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<product> Products { get; set; }
    }
}
