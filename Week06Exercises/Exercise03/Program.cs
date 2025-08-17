// Import Entity Framework Core voor database operaties
using Microsoft.EntityFrameworkCore;
// Import onze eigen Data namespace voor AppDbContext
using food.Data;
// Import onze eigen Models namespace voor Food en Category classes
using food.Models;

// Main methode - entry point van de applicatie
public class Program
{
    public static void Main(string[] args)
    {
        // Maak een DbContextOptionsBuilder om de database configuratie op te zetten
        var options = new DbContextOptionsBuilder<AppDbContext>()
        // Configureer de MySQL database connectie met server, database naam, gebruiker en wachtwoord
        .UseMySQL("server=localhost;database=food;user=root;password=9370")
        // Bouw de opties en maak ze klaar voor gebruik
        .Options;

        // Maak een nieuwe AppDbContext instantie met de geconfigureerde opties
        // 'using' zorgt ervoor dat de database connectie automatisch wordt gesloten na gebruik
        using var db = new AppDbContext(options);

        // Controleer of er al data in de foods tabel staat
        if (!db.foods.Any())
        {
            // Als de tabel leeg is, voeg dan seed data toe
            db.foods.AddRange(
                // Voeg een nieuwe Food toe: tomatensoep met prijs €5.50 en categorie LowCarbFood
                new Food { Name = "tomato soup", Description = "Classic Soup", Price = 5.50m, Category = Category.LowCarbFood },
                // Voeg een nieuwe Food toe: burger met prijs €8.60 en categorie Junkfood
                new Food { Name = "burger", Description = "Classic burger", Price = 8.60m, Category = Category.Junkfood },
                // Voeg een nieuwe Food toe: chocolade cake met prijs €8.60 en categorie LowCarbFood
                new Food { Name = "Choclate cake", Description = "Classic choco mouse", Price = 8.60m, Category = Category.LowCarbFood }
            );

            // Sla alle wijzigingen op in de database
            db.SaveChanges();

            // Print een bevestigingsbericht dat de data is toegevoegd
            Console.WriteLine("Seeded foods");
        }

        // Print een header voor de lijst van foods
        Console.WriteLine("foods");
        // Loop door alle foods in de database, gesorteerd op ID
        // AsNoTracking() verbetert performance omdat we alleen lezen, niet wijzigen
        foreach (var f in db.foods.AsNoTracking().OrderBy(f => f.Id))
        {
            // Print elke food met ID, naam, categorie en prijs (2 decimalen)
            Console.WriteLine($"{f.Id}:  {f.Name} {f.Category} €{f.Price:F2} ");
        }
    }
}
