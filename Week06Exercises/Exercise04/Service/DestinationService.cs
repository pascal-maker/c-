// Import required namespaces for models and repositories
using Exercise04.Models;
using Exercise04.Repositories;

// Namespace for service implementations
namespace Exercise04.Services
{
    // DestinationService class - implements IDestinationService interface
    // This class contains business logic for destination operations
    // Handles destination creation and retrieval operations
    // Acts as an intermediary between the presentation layer and repository layer
    public class DestinationService : IDestinationService
    {
        // Private field to hold the destination repository
        // Uses interface for loose coupling and dependency injection
        private readonly IDestinationRepository _destinationRepo;

        // Constructor - dependency injection of IDestinationRepository
        // This allows for loose coupling and easier testing
        public DestinationService(IDestinationRepository destinationRepo)
        {
            _destinationRepo = destinationRepo;
        }

        // AddDestination method - creates a new destination with the provided name
        // Business logic: Creates Destination object and delegates to repository
        // Parameter: name - the name of the destination to create
        public void AddDestination(string name)
        {
            var destination = new Destination { Name = name };
            _destinationRepo.AddDestination(destination);
        }

        // GetAllDestinations method - retrieves all destinations from the repository
        // Returns the complete list of destinations with their related data
        public List<Destination> GetAllDestinations()
        {
            return _destinationRepo.GetAllDestinations();
        }
    }
}