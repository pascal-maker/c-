// Import Entity Framework Core voor database context functionaliteit
using Microsoft.EntityFrameworkCore;
// Import onze eigen Models namespace voor Food class
using food.Models;

// Namespace voor database gerelateerde classes
namespace food.Data
{
    // AppDbContext class - hoofdclass voor database operaties
    // Erft over van DbContext (Entity Framework Core base class)
    public class AppDbContext : DbContext
    {
        // DbSet property - vertegenwoordigt de 'foods' tabel in de database
        // DbSet<Food> betekent dat deze property een collectie van Food objecten beheert
        public DbSet<Food> foods{ get; set; } 

        // Constructor - ontvangt database configuratie opties
        // base(options) geeft de opties door aan de parent DbContext class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        // OnModelCreating methode - wordt aangeroepen door Entity Framework Core
        // om het database model en relaties te configureren
        // ModelBuilder is een hulpmiddel om database schema te configureren vanuit code
        // Het wordt gebruikt om dingen te doen zoals:
        // - Tabellen een naam geven
        // - Relaties instellen (one-to-many, many-to-many)
        // - Constraints instellen
        // - Seed data toevoegen
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configureer de Food entity
            modelBuilder.Entity<Food>()
            // Configureer de Price property
            .Property(f => f.Price)
            // Stel precisie in: 10 cijfers totaal, 2 decimalen
            // Dit zorgt ervoor dat prijzen correct worden opgeslagen (bijv. 12345678.90)
            .HasPrecision(10, 2);
        }
    }
}