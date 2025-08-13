using Exercise04.Models;
using Exercise04.Repositories;
namespace Exercise04.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepo;

        public DestinationService(IDestinationRepository destinationRepo)
        {
            _destinationRepo = destinationRepo;
        }

        public void AddDestination(string name)
        {
            var destination = new Destination { Name = name };
            _destinationRepo.AddDestination(destination);
        }

        public List<Destination> GetAllDestinations()
        {
            return _destinationRepo.GetAllDestinations();
        }
    }
}