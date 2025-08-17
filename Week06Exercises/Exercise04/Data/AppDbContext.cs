// Import Entity Framework Core voor database context functionaliteit
using Microsoft.EntityFrameworkCore;
// Import onze eigen Models namespace voor alle model classes
using Exercise04.Models;

// Namespace voor database gerelateerde classes
namespace Exercise04.Data
{
    // AppDbContext class - hoofdclass voor database operaties
    // Erft over van DbContext (Entity Framework Core base class)
    public class AppDbContext : DbContext
    {
        // DbSet property - vertegenwoordigt de 'Destinations' tabel in de database
        // DbSet<Destination> betekent dat deze property een collectie van Destination objecten beheert
        // = null! betekent dat deze property niet null kan zijn (null-forgiving operator)
        public DbSet<Destination> Destinations { get; set; } = null!;

        // DbSet property - vertegenwoordigt de 'Guide' tabel in de database
        // DbSet<Guide> betekent dat deze property een collectie van Guide objecten beheert
        public DbSet<Guide> Guide { get; set; } = null!;

        // DbSet property - vertegenwoordigt de 'Passport' tabel in de database
        // DbSet<Passport> betekent dat deze property een collectie van Passport objecten beheert
        public DbSet<Passport> Passport { get; set; } = null!;

        // DbSet property - vertegenwoordigt de 'Tours' tabel in de database
        // DbSet<Tour> betekent dat deze property een collectie van Tour objecten beheert
        public DbSet<Tour> Tours { get; set; } = null!;

        // DbSet property - vertegenwoordigt de 'Travellers' tabel in de database
        // DbSet<Traveler> betekent dat deze property een collectie van Traveler objecten beheert
        public DbSet<Traveler> Travellers { get; set; } = null!;

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
            // Roep de base OnModelCreating methode aan
            base.OnModelCreating(modelBuilder);

            // Configureer de Traveler entity
            modelBuilder.Entity<Traveler>()
            // Stel one-to-one relatie in met Passport
            .HasOne(t => t.Passport)        // Traveler heeft één Passport
            .WithOne(p => p.Traveler)       // Passport heeft één Traveler
            .HasForeignKey<Passport>(p => p.Id); // Passport.Id is de foreign key

            // Configureer de Traveler entity
            modelBuilder.Entity<Traveler>()
            // Stel many-to-many relatie in met Destination
            .HasMany(t => t.Destinations)   // Traveler heeft veel Destinations
            .WithMany(d => d.Travelers);    // Destination heeft veel Travelers

            // Configureer de Tour entity
            modelBuilder.Entity<Tour>()
            // Stel one-to-many relatie in met Guide
            .HasOne(t => t.Guide)           // Tour heeft één Guide
            .WithMany(g => g.Tours)         // Guide heeft veel Tours
            .HasForeignKey(t => t.GuideId); // Tour.GuideId is de foreign key
        }
    }
}
