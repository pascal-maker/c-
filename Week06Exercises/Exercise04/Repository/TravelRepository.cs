// Import required namespaces for Entity Framework Core and data access
using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;

// Namespace for repository implementations
namespace Exercise04.Repositories
{
    // TravelRepository class - implements ITravelRepository interface
    // This class handles all database operations related to travelers, passports, and destinations
    // Uses Entity Framework Core for data access and implements the repository pattern
    public class TravelRepository : ITravelRepository
    {
        // Private field to hold the database context
        // readonly ensures this field can only be set in the constructor
        private readonly AppDbContext _context;

        // Constructor - dependency injection of AppDbContext
        // This allows for loose coupling and easier testing
        public TravelRepository(AppDbContext context)
        {
            _context = context;
        }

        // AddTraveler method - adds a new traveler to the database
        // Saves changes immediately to persist the new traveler
        public void AddTraveler(Traveler traveler)
        {
            _context.Travellers.Add(traveler);
            _context.SaveChanges();
        }

        // GetAllTravelers method - retrieves all travelers with their related data
        // Uses Include() to eagerly load Passport and Destinations navigation properties
        // This prevents N+1 query problems and ensures all related data is available
        public List<Traveler> GetAllTravelers()
        {
            return _context.Travellers
                .Include(t => t.Passport)
                .Include(t => t.Destinations)
                .ToList();
        }

        // GetTravelerById method - finds a specific traveler by ID
        // Returns null if no traveler is found with the given ID
        // Includes related Passport and Destinations data
        public Traveler GetTravelerById(int id)
        {
            return _context.Travellers
                .Include(t => t.Passport)
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == id);
        }

        // UpdateTraveler method - updates an existing traveler in the database
        // Saves changes immediately to persist the updates
        public void UpdateTraveler(Traveler traveler)
        {
            _context.Travellers.Update(traveler);
            _context.SaveChanges();
        }

        // DeleteTraveler method - removes a traveler from the database by ID
        // First finds the traveler, then removes it and saves changes
        public void DeleteTraveler(int id)
        {
            var traveler = _context.Travellers.Find(id);
            _context.Travellers.Remove(traveler);
            _context.SaveChanges();
        }

        // AssignPassport method - assigns a passport to a specific traveler
        // Creates a one-to-one relationship between traveler and passport
        public void AssignPassport(int travelerId, Passport passport)
        {
            var traveler = _context.Travellers.FirstOrDefault(t => t.Id == travelerId);
            traveler.Passport = passport;
            _context.SaveChanges();
        }

        // AssignDestination method - assigns a destination to a traveler
        // Creates a many-to-many relationship between traveler and destination
        // Uses Include() to ensure Destinations collection is loaded
        public void AssignDestination(int travelerId, Destination destination)
        {
            var traveler = _context.Travellers
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == travelerId);
            traveler.Destinations.Add(destination);
            _context.SaveChanges();
        }

        // RemoveDestination method - removes a destination from a traveler
        // Removes the many-to-many relationship between traveler and destination
        public void RemoveDestination(int travelerId, int destinationId)
        {
            var traveler = _context.Travellers
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == travelerId);
            var destination = traveler.Destinations.FirstOrDefault(d => d.Id == destinationId);
            traveler.Destinations.Remove(destination);
            _context.SaveChanges();
        }

        // GetDestinationsByTraveler method - gets all destinations for a specific traveler
        // Returns a list of destinations that the traveler is assigned to
        public List<Destination> GetDestinationsByTraveler(int travelerId)
        {
            var traveler = _context.Travellers
                .Include(t => t.Destinations)
                .FirstOrDefault(t => t.Id == travelerId);

            return traveler.Destinations.ToList();
        }

        // GetTravelersByDestination method - gets all travelers for a specific destination
        // Uses LINQ Where clause with Any() to filter travelers who have the specified destination
        public List<Traveler> GetTravelersByDestination(int destinationId)
        {
            return _context.Travellers
                .Include(t => t.Destinations)
                .Where(t => t.Destinations.Any(d => d.Id == destinationId))
                .ToList();
        }
    }
}