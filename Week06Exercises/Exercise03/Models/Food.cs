// Namespace voor alle model classes in dit project
namespace food.Models;

// Food class - vertegenwoordigt een voedsel item in de database
public class Food
{
    // Primary key - unieke identifier voor elke food record
    // Auto-increment door Entity Framework Core
    public int Id { get; set; }

    // Naam van het voedsel item (bijv. "tomato soup", "burger")
    // String property die de naam van het voedsel bevat
    public string Name { get; set; }

    // Beschrijving van het voedsel item (bijv. "Classic Soup", "Classic burger")
    // String property die meer details geeft over het voedsel
    public string Description { get; set; }

    // Prijs van het voedsel item in euro's
    // Decimal type voor nauwkeurige prijs berekeningen (geen floating point errors)
    public decimal Price { get; set; }

    // Categorie van het voedsel (Junkfood, LowCarbFood, Spirits)
    // Enum property die het type voedsel classificeert
    public Category Category { get; set; }
}
