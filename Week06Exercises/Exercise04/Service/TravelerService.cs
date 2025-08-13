using Exercise04.Models;
using Exercise04.Repositories;

namespace Exercise04.Services
{
    public class TravelerService : ITravelerService
    {
        private readonly ITravelRepository _travelerRepo;

        public TravelerService(ITravelRepository travelerRepo)
        {
            _travelerRepo = travelerRepo;
        }

        public void AddTraveler(string fullName)
        {
            var traveler = new Traveler { FullName = fullName };
            _travelerRepo.AddTraveler(traveler);
        }

        public List<Traveler> GetAllTravelers()
        {
            return _travelerRepo.GetAllTravelers();
        }

        public Traveler GetTravelerById(int id)
        {
            return _travelerRepo.GetTravelerById(id);
        }

        public void UpdateTraveler(Traveler traveler)
        {
            _travelerRepo.UpdateTraveler(traveler);
        }

        public void DeleteTraveler(int id)
        {
            _travelerRepo.DeleteTraveler(id);
        }

        public List<Traveler> GetTravelersByDestination(int destinationId)
        {
            return _travelerRepo.GetTravelersByDestination(destinationId);
        }
    }
}