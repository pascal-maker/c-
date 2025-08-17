// Import Data Annotations voor validatie attributen
using System.ComponentModel.DataAnnotations;

// Namespace voor alle model classes in dit project
namespace Exercise04.Models
{
    // Passport class - vertegenwoordigt een paspoort in het reisbureau systeem
    // Deze class heeft een one-to-one relatie met Traveler class
    public class Passport
    {
        // Primary key - unieke identifier voor elk paspoort
        // Auto-increment door Entity Framework Core
        public int Id { get; set; }

        // Paspoort nummer - unieke identificatie van het paspoort
        // [Required] - deze property is verplicht (mag niet null of leeg zijn)
        // [MaxLength(200)] - maximale lengte van 200 karakters
        [Required]
        [MaxLength(200)]
        public string PassportNumber { get; set; }

        // Navigation property - relatie naar Traveler class
        // Elk paspoort behoort tot één reiziger (one-to-one relatie)
        // Dit is de inverse relatie van Traveler.Passport
        public Traveler Traveler { get; set; }
    }
}

// Comment: Een reiziger heeft altijd één paspoort (1-1 relatie)