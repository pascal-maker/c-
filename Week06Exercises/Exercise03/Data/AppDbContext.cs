using Microsoft.EntityFrameworkCore;
using Exercise03.Models;

namespace Exercise03.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
            .Property(f => f.Price)
            .HasPrecision(10, 2);
        }
        }
    }
