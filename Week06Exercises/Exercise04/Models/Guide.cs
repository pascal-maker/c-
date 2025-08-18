// Import Data Annotations voor validatie attributen
using System.ComponentModel.DataAnnotations;

// Namespace voor alle model classes in dit project
namespace Exercise04.Models
{
    // Guide class - vertegenwoordigt een reisgids in het reisbureau systeem
    // Deze class heeft een one-to-many relatie met Tour class
    public class Guide
    {
        // Primary key - unieke identifier voor elke gids
        // Auto-increment door Entity Framework Core
        public int Id { get; set; }

        // Naam van de gids (bijv. "Jan Jansen", "Maria Garcia")
        // [Required] - deze property is verplicht (mag niet null of leeg zijn)
        // [MaxLength(200)] - maximale lengte van 200 karakters
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        // Navigation property - relatie naar Tour class
        // Een gids kan meerdere tours begeleiden (one-to-many relatie: Guide -> Tour)
        // ICollection betekent dat een gids meerdere tours kan hebben
        public ICollection<Tour> Tours { get; set; }
    }
}

// Comment: Een gids kan meerdere tours doen