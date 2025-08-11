using Exercise04.Models;
using Exercise04.Repositories;

namespace Exercise04.Services
{
    public class TravelerDestinationService : ITravelerDestinationService
    {
        private readonly ITravelRepository _travelerRepo;
        private readonly IDestinationRepository _destinationRepo;

        public TravelerDestinationService(ITravelRepository travelerRepo, IDestinationRepository destinationRepo)
        {
            _travelerRepo = travelerRepo;
            _destinationRepo = destinationRepo;
        }

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

            _travelerRepo.AssignDestination(travelerId, destination);
        }

        public void RemoveDestination(int travelerId, int destinationId)
        {
            // Validate that traveler exists
            var traveler = _travelerRepo.GetTravelerById(travelerId);
            if (traveler == null)
                throw new ArgumentException($"Traveler with ID {travelerId} not found");

            _travelerRepo.RemoveDestination(travelerId, destinationId);
        }

        public List<Destination> GetDestinationsByTraveler(int travelerId)
        {
            var traveler = _travelerRepo.GetTravelerById(travelerId);
            if (traveler == null)
                throw new ArgumentException($"Traveler with ID {travelerId} not found");

            return _travelerRepo.GetDestinationsByTraveler(travelerId);
        }

        public List<Traveler> GetTravelersByDestination(int destinationId)
        {
            var destination = _destinationRepo.GetDestinationByID(destinationId);
            if (destination == null)
                throw new ArgumentException($"Destination with ID {destinationId} not found");

            return _travelerRepo.GetTravelersByDestination(destinationId);
        }
    }
}
