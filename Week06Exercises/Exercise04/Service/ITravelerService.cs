using Exercise04.Models;

namespace Exercise04.Services
{
    public interface ITravelerService
    {
        void AddTraveler(string fullName);
        List<Traveler> GetAllTravelers();
        Traveler GetTravelerById(int id);
        void UpdateTraveler(Traveler traveler);
        void DeleteTraveler(int id);
        List<Traveler> GetTravelersByDestination(int destinationId);
    }

   

    
}