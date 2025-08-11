using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Exercise04.Data;
namespace Exercise04
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySQL("server=localhost;database=Exercise04_clean;user=root;password=9370");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

