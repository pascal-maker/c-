using Exercise04.Models;
namespace Exercise04.Repositories
{
    public interface ITravelRepository
    {
        void AddTraveler(Traveler traveler);
        List<Traveler> GetAllTravelers();
        Traveler GetTravelerById(int id);
        void UpdateTraveler(Traveler traveler);
        void DeleteTraveler(int id);
        void AssignPassport(int travelerId, Passport passport);
        void AssignDestination(int travelerId, Destination destination);
        void RemoveDestination(int travelerId, int destinationId);
        List<Destination> GetDestinationsByTraveler(int travelerId);
        List<Traveler> GetTravelersByDestination(int destinationId);
    }
}
