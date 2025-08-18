// Import onze eigen Models namespace voor Traveler class
using Exercise04.Models;

// Namespace voor service interfaces en implementaties
namespace Exercise04.Services
{
    // ITravelerService interface - definieert de contract voor reiziger business logic
    // Service layer bevat business logic en valideert data voordat het naar repository gaat
    public interface ITravelerService
    {
        // Voeg een nieuwe reiziger toe met alleen de naam
        // Parameter: fullName - de volledige naam van de reiziger
        // Service layer maakt het Traveler object aan en valideert de input
        void AddTraveler(string fullName);
        
        // Haal alle reizigers op uit de database
        // Return: List<Traveler> - lijst van alle reizigers
        List<Traveler> GetAllTravelers();
        
        // Haal een specifieke reiziger op basis van ID
        // Parameter: id - de ID van de reiziger
        // Return: Traveler - de gevonden reiziger of null als niet gevonden
        Traveler GetTravelerById(int id);
        
        // Update een bestaande reiziger in de database
        // Parameter: traveler - het Traveler object met bijgewerkte gegevens
        // Service layer valideert de data voordat het wordt opgeslagen
        void UpdateTraveler(Traveler traveler);
        
        // Verwijder een reiziger uit de database op basis van ID
        // Parameter: id - de ID van de reiziger die verwijderd moet worden
        void DeleteTraveler(int id);
        
        // Haal alle reizigers op voor een specifieke bestemming
        // Parameter: destinationId - de ID van de bestemming
        // Return: List<Traveler> - lijst van reizigers voor deze bestemming
        List<Traveler> GetTravelersByDestination(int destinationId);
    }
}