// Import Data Annotations voor validatie attributen
using System.ComponentModel.DataAnnotations;

// Namespace voor alle model classes in dit project
namespace Exercise04.Models
{
    // Tour class - vertegenwoordigt een georganiseerde reis/tour in het reisbureau systeem
    // Deze class heeft een relatie met Guide class
    public class Tour
    {
        // Primary key - unieke identifier voor elke tour
        // Auto-increment door Entity Framework Core
        public int Id { get; set; }

        // Titel van de tour (bijv. "Parijs City Tour", "Rome Historical Walk")
        // [Required] - deze property is verplicht (mag niet null of leeg zijn)
        // [MaxLength(200)] - maximale lengte van 200 karakters
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        // Foreign key - verwijst naar de Guide die deze tour begeleidt
        // Elke tour heeft één gids (one-to-many relatie: Guide -> Tour)
        public int GuideId { get; set; }

        // Navigation property - relatie naar Guide class
        // Elke tour wordt begeleid door één gids
        public Guide Guide { get; set; }
    }
}

// Comment: Inderdaad per tour één gids, maar GuideId was vergeten (foreign key)