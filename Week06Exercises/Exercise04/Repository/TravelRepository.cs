using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise04.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly AppDbContext _context;

        public TravelRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTraveler(Traveler traveler)
        {
            _context.Travellers.Add(traveler);
            _context.SaveChanges();
        }

        public List<Traveler> GetAllTravelers()
        {
            return _context.Travellers
                .Include(t => t.Passport)
                .Include(t => t.Destinations)
                .ToList();
        }

        public Traveler GetTravelerById(int id)
        {
            return _context.Travellers
                .Include(t => t.Passport)
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTraveler(Traveler traveler)
        {
            _context.Travellers.Update(traveler);
            _context.SaveChanges();
        }

        public void DeleteTraveler(int id)
        {
            var traveler = _context.Travellers.Find(id);
            _context.Travellers.Remove(traveler);
            _context.SaveChanges();
        }

        public void AssignPassport(int travelerId, Passport passport)
        {
            var traveler = _context.Travellers.FirstOrDefault(t => t.Id == travelerId);
            traveler.Passport = passport;
            _context.SaveChanges();
        }

        public void AssignDestination(int travelerId, Destination destination)
        {
            var traveler = _context.Travellers
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == travelerId);
            traveler.Destinations.Add(destination);
            _context.SaveChanges();
        }

        public void RemoveDestination(int travelerId, int destinationId)
        {
            var traveler = _context.Travellers
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == travelerId);
            var destination = traveler.Destinations.FirstOrDefault(d => d.Id == destinationId);
            traveler.Destinations.Remove(destination);
            _context.SaveChanges();
        }

        public List<Destination> GetDestinationsByTraveler(int travelerId)
        {
            var traveler = _context.Travellers
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == travelerId);

            return traveler.Destinations.ToList();
        }

        public List<Traveler> GetTravelersByDestination(int destinationId)
        {
            return _context.Travellers
                .Include(t => t.Destinations)
                .Where(t => t.Destinations.Any(d => d.Id == destinationId))
                .ToList();
        }
    }
}