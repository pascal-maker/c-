// Import required namespaces for models and repositories
using Exercise04.Models;
using Exercise04.Repositories;

// Namespace for service implementations
namespace Exercise04.Services
{
    // TravelerDestinationService class - implements ITravelerDestinationService interface
    // This class contains business logic for managing relationships between travelers and destinations
    // Handles the many-to-many relationship between travelers and destinations
    // Coordinates between traveler and destination repositories
    public class TravelerDestinationService : ITravelerDestinationService
    {
        // Private fields to hold repository dependencies
        // Uses interfaces for loose coupling and dependency injection
        private readonly ITravelRepository _travelerRepo;
        private readonly IDestinationRepository _destinationRepo;

        // Constructor - dependency injection of traveler and destination repositories
        // This allows for loose coupling and easier testing
        public TravelerDestinationService(ITravelRepository travelerRepo, IDestinationRepository destinationRepo)
        {
            _travelerRepo = travelerRepo;
            _destinationRepo = destinationRepo;
        }

        // AssignDestination method - assigns a destination to a specific traveler
        // Business logic: Validates both traveler and destination exist before assignment
        // Parameters: travelerId - ID of the traveler to assign destination to
        //             destinationId - ID of the destination to assign
        public void AssignDestination(int travelerId, int destinationId)
        {
            // Validate that traveler exists
            var traveler = _travelerRepo.GetTravelerById(travelerId);
            if (traveler == null)
                throw new ArgumentException($"Traveler with ID {travelerId} not found");

            // Validate that destination exists
            var destination = _destinationRepo.GetDestinationByID(destinationId);
            if (destination == null)
                throw new ArgumentException($"Destination with ID {destinationId} not found");

            // Delegate to repository to create the many-to-many relationship
            _travelerRepo.AssignDestination(travelerId, destination);
        }

        // RemoveDestination method - removes a destination from a specific traveler
        // Business logic: Validates traveler exists before removal
        // Parameters: travelerId - ID of the traveler to remove destination from
        //             destinationId - ID of the destination to remove
        public void RemoveDestination(int travelerId, int destinationId)
        {
            // Validate that traveler exists
            var traveler = _travelerRepo.GetTravelerById(travelerId);
            if (traveler == null)
                throw new ArgumentException($"Traveler with ID {travelerId} not found");

            // Delegate to repository to remove the many-to-many relationship
            _travelerRepo.RemoveDestination(travelerId, destinationId);
        }

        // GetDestinationsByTraveler method - retrieves all destinations for a specific traveler
        // Business logic: Validates traveler exists before retrieving destinations
        // Parameter: travelerId - ID of the traveler whose destinations to find
        public List<Destination> GetDestinationsByTraveler(int travelerId)
        {
            var traveler = _travelerRepo.GetTravelerById(travelerId);
            if (traveler == null)
                throw new ArgumentException($"Traveler with ID {travelerId} not found");

            return _travelerRepo.GetDestinationsByTraveler(travelerId);
        }

        // GetTravelersByDestination method - retrieves all travelers for a specific destination
        // Business logic: Validates destination exists before retrieving travelers
        // Parameter: destinationId - ID of the destination whose travelers to find
        public List<Traveler> GetTravelersByDestination(int destinationId)
        {
            var destination = _destinationRepo.GetDestinationByID(destinationId);
            if (destination == null)
                throw new ArgumentException($"Destination with ID {destinationId} not found");

            return _travelerRepo.GetTravelersByDestination(destinationId);
        }
    }
}
