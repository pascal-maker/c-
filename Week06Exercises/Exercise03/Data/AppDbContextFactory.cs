using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Exercise03.Data;
namespace Exercise03
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySQL("server=localhost;database=Ex03;user=root;password=9370");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}