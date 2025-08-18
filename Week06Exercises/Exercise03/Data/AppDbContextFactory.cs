// Import Entity Framework Core voor database context functionaliteit
using Microsoft.EntityFrameworkCore;
// Import Entity Framework Core Design tools voor design-time operaties
using Microsoft.EntityFrameworkCore.Design;
// Import MySQL Entity Framework Core voor MySQL database ondersteuning
using MySql.EntityFrameworkCore;
// Import onze eigen Data namespace voor AppDbContext
using food.Data;

// Namespace voor database gerelateerde classes
namespace food.Data
{
    // AppDbContextFactory class - factory voor het maken van AppDbContext instanties
    // Implementeert IDesignTimeDbContextFactory voor Entity Framework Core tools
    // Deze interface wordt gebruikt door EF Core tools zoals migrations en scaffolding
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        // CreateDbContext methode - maakt een nieuwe AppDbContext instantie
        // Wordt aangeroepen door EF Core tools tijdens design-time (niet runtime)
        // args parameter bevat command line argumenten (meestal leeg)
        public AppDbContext CreateDbContext(string[] args)
        {
            // Maak een nieuwe DbContextOptionsBuilder voor AppDbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Configureer de MySQL database connectie string
            // server=localhost - database server locatie
            // database=food - naam van de database
            // user=root - database gebruiker
            // password=9370 - wachtwoord voor de database gebruiker
            optionsBuilder.UseMySQL("server=localhost;database=food;user=root;password=9370");
            // Maak en retourneer een nieuwe AppDbContext met de geconfigureerde opties
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
