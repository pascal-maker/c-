// Import Data Annotations voor validatie attributen
using System.ComponentModel.DataAnnotations;

// Namespace voor alle model classes in dit project
namespace Exercise04.Models
{
    // Traveler class - vertegenwoordigt een reiziger in het reisbureau systeem
    // Deze class heeft relaties met Passport en Destination classes
    public class Traveler
    {
        // Primary key - unieke identifier voor elke reiziger
        // Auto-increment door Entity Framework Core
        public int Id { get; set; }

        // Volledige naam van de reiziger
        // [Required] - deze property is verplicht (mag niet null of leeg zijn)
        // [MaxLength(100)] - maximale lengte van 100 karakters
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        // Navigation property - relatie naar Passport class
        // Elke reiziger heeft één paspoort (one-to-one relatie)
        public Passport Passport { get; set; }

        // Navigation property - relatie naar Destination class
        // Elke reiziger kan naar meerdere bestemmingen reizen (one-to-many relatie)
        // ICollection betekent dat een reiziger meerdere bestemmingen kan hebben
        public ICollection<Destination> Destinations { get; set; }
    }
}

// Comment: Een reiziger heeft een paspoort nodig en kan naar meerdere bestemmingen reizen