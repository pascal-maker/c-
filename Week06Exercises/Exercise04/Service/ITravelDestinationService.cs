using Exercise04.Models;
namespace Exercise04.Services
{

    public interface ITravelerDestinationService
    {
        void AssignDestination(int travelerId, int destinationId);
        void RemoveDestination(int travelerId, int destinationId);
        List<Destination> GetDestinationsByTraveler(int travelerId);
        List<Traveler> GetTravelersByDestination(int destinationId);
    }
}    