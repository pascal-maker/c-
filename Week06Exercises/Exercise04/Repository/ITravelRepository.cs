// Import onze eigen Models namespace voor Traveler, Passport en Destination classes
using Exercise04.Models;

// Namespace voor repository interfaces en implementaties
namespace Exercise04.Repositories
{
    // ITravelRepository interface - definieert de contract voor reiziger database operaties
    // Interface zorgt voor loose coupling en maakt testing en dependency injection mogelijk
    public interface ITravelRepository
    {
        // Voeg een nieuwe reiziger toe aan de database
        // Parameter: traveler - het Traveler object dat toegevoegd moet worden
        void AddTraveler(Traveler traveler);
        
        // Haal alle reizigers op uit de database
        // Return: List<Traveler> - lijst van alle reizigers
        List<Traveler> GetAllTravelers();
        
        // Haal een specifieke reiziger op basis van ID
        // Parameter: id - de ID van de reiziger
        // Return: Traveler - de gevonden reiziger of null als niet gevonden
        Traveler GetTravelerById(int id);
        
        // Update een bestaande reiziger in de database
        // Parameter: traveler - het Traveler object met bijgewerkte gegevens
        void UpdateTraveler(Traveler traveler);
        
        // Verwijder een reiziger uit de database op basis van ID
        // Parameter: id - de ID van de reiziger die verwijderd moet worden
        void DeleteTraveler(int id);
        
        // Ken een paspoort toe aan een reiziger
        // Parameter: travelerId - de ID van de reiziger
        // Parameter: passport - het Passport object dat toegekend moet worden
        void AssignPassport(int travelerId, Passport passport);
        
        // Ken een bestemming toe aan een reiziger
        // Parameter: travelerId - de ID van de reiziger
        // Parameter: destination - de Destination die toegekend moet worden
        void AssignDestination(int travelerId, Destination destination);
        
        // Verwijder een bestemming van een reiziger
        // Parameter: travelerId - de ID van de reiziger
        // Parameter: destinationId - de ID van de bestemming die verwijderd moet worden
        void RemoveDestination(int travelerId, int destinationId);
        
        // Haal alle bestemmingen op voor een specifieke reiziger
        // Parameter: travelerId - de ID van de reiziger
        // Return: List<Destination> - lijst van bestemmingen voor deze reiziger
        List<Destination> GetDestinationsByTraveler(int travelerId);
        
        // Haal alle reizigers op voor een specifieke bestemming
        // Parameter: destinationId - de ID van de bestemming
        // Return: List<Traveler> - lijst van reizigers voor deze bestemming
        List<Traveler> GetTravelersByDestination(int destinationId);
    }
}
