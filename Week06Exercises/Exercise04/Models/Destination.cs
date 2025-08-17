// Import Data Annotations voor validatie attributen
using System.ComponentModel.DataAnnotations;

// Namespace voor alle model classes in dit project
namespace Exercise04.Models
{
    // Destination class - vertegenwoordigt een reisbestemming in het reisbureau systeem
    // Deze class heeft een many-to-many relatie met Traveler class
    public class Destination
    {
        // Primary key - unieke identifier voor elke bestemming
        // Auto-increment door Entity Framework Core
        public int Id { get; set; }

        // Naam van de reisbestemming (bijv. "Parijs", "New York", "Tokyo")
        // [Required] - deze property is verplicht (mag niet null of leeg zijn)
        // [MaxLength(200)] - maximale lengte van 200 karakters
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        // Navigation property - relatie naar Traveler class
        // Meerdere reizigers kunnen naar dezelfde bestemming reizen (many-to-many relatie)
        // ICollection betekent dat een bestemming door meerdere reizigers bezocht kan worden
        public ICollection<Traveler> Travelers { get; set; }
    }
}

// Comment: Vergeet niet using System.ComponentModel.DataAnnotations - dit heb je nodig voor Required en MaxLength
// Comment: Je moet rekening houden dat meerdere reizigers naar dezelfde bestemming kunnen reizen
