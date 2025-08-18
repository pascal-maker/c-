// Import Entity Framework Core for database context functionality
using Microsoft.EntityFrameworkCore;
// Import design-time factory interface for Entity Framework migrations
using Microsoft.EntityFrameworkCore.Design;
// Import our data namespace
using Exercise04.Data;

// Namespace for the main application
namespace Exercise04
{
    // AppDbContextFactory class - implements IDesignTimeDbContextFactory interface
    // This class is used by Entity Framework Core during design-time operations
    // such as creating migrations, updating database schema, etc.
    // It provides a way to create DbContext instances when the application is not running
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        // CreateDbContext method - creates and configures a new AppDbContext instance
        // This method is called by Entity Framework tools (like dotnet ef migrations)
        // args parameter contains command line arguments (usually empty for design-time)
        public AppDbContext CreateDbContext(string[] args)
        {
            // Create options builder for configuring database connection
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
            // Configure MySQL connection string for design-time operations
            // This should match the connection string used in the main application
            optionsBuilder.UseMySQL("server=localhost;database=Exercise04_clean;user=root;password=9370");

            // Return new AppDbContext instance with configured options
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

