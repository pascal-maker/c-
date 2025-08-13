using Microsoft.EntityFrameworkCore;
using Exercise04.Models;

namespace Exercise04.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; } = null!;

        public DbSet<Guide> Guide { get; set; } = null!;

        public DbSet<Passport> Passport { get; set; } = null!;


        public DbSet<Tour> Tours { get; set; } = null!;

        public DbSet<Traveler> Travellers { get; set; } = null!;





        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // n EF Core is ModelBuilder een hulpmiddel om je database schema te configureren vanuit code.

//Het wordt gebruikt in OnModelCreating (in je DbContext) om dingen te doen zoals:Tabellen een naam gevenstellen (one-to-many, many-to-many)Constraints instellenSeed data toevoegen
        // This method is called by the runtime to configure the model and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Traveler>()
            .HasOne(t => t.Passport)
            .WithOne(p => p.Traveler)
            .HasForeignKey<Passport>(p => p.Id);



            modelBuilder.Entity<Traveler>()
            .HasMany(t => t.Destinations)
            .WithMany(d => d.Travelers);


            modelBuilder.Entity<Tour>()
            .HasOne(t => t.Guide)
            .WithMany(g => g.Tours)
            .HasForeignKey(t => t.GuideId);





        }

    }
}
