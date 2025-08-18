// Import required namespaces for models and repositories
using Exercise04.Models;
using Exercise04.Repositories;

// Namespace for service implementations
namespace Exercise04.Services
{
    // TravelerService class - implements ITravelerService interface
    // This class contains business logic for traveler operations
    // Acts as an intermediary between the presentation layer and repository layer
    // Handles data validation and business rules before delegating to repositories
    public class TravelerService : ITravelerService
    {
        // Private field to hold the traveler repository
        // Uses interface for loose coupling and dependency injection
        private readonly ITravelRepository _travelerRepo;

        // Constructor - dependency injection of ITravelRepository
        // This allows for loose coupling and easier testing
        public TravelerService(ITravelRepository travelerRepo)
        {
            _travelerRepo = travelerRepo;
        }

        // AddTraveler method - creates a new traveler with the provided name
        // Business logic: Creates Traveler object and delegates to repository
        // Parameter: fullName - the full name of the traveler to create
        public void AddTraveler(string fullName)
        {
            var traveler = new Traveler { FullName = fullName };
            _travelerRepo.AddTraveler(traveler);
        }

        // GetAllTravelers method - retrieves all travelers from the repository
        // Returns the complete list of travelers with their related data
        public List<Traveler> GetAllTravelers()
        {
            return _travelerRepo.GetAllTravelers();
        }

        // GetTravelerById method - finds a specific traveler by ID
        // Delegates the search operation to the repository layer
        // Parameter: id - the ID of the traveler to find
        public Traveler GetTravelerById(int id)
        {
            return _travelerRepo.GetTravelerById(id);
        }

        // UpdateTraveler method - updates an existing traveler
        // Delegates the update operation to the repository layer
        // Parameter: traveler - the Traveler object with updated data
        public void UpdateTraveler(Traveler traveler)
        {
            _travelerRepo.UpdateTraveler(traveler);
        }

        // DeleteTraveler method - removes a traveler from the system
        // Delegates the deletion operation to the repository layer
        // Parameter: id - the ID of the traveler to delete
        public void DeleteTraveler(int id)
        {
            _travelerRepo.DeleteTraveler(id);
        }

        // GetTravelersByDestination method - finds all travelers for a specific destination
        // Uses the many-to-many relationship to find travelers assigned to a destination
        // Parameter: destinationId - the ID of the destination to search for
        public List<Traveler> GetTravelersByDestination(int destinationId)
        {
            return _travelerRepo.GetTravelersByDestination(destinationId);
        }
    }
}