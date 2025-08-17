// Import required namespaces for Entity Framework Core and data access
using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;

// Namespace for repository implementations
namespace Exercise04.Repositories
{
    // DestinationRepository class - implements IDestinationRepository interface
    // This class handles all database operations related to destinations
    // Manages the many-to-many relationship between travelers and destinations
    public class DestinationRepository : IDestinationRepository
    {
        // Private field to hold the database context
        // readonly ensures this field can only be set in the constructor
        private readonly AppDbContext _context;

        // Constructor - dependency injection of AppDbContext
        // This allows for loose coupling and easier testing
        public DestinationRepository(AppDbContext context)
        {
            _context = context;
        }

        // AddDestination method - adds a new destination to the database
        // Saves changes immediately to persist the new destination
        // Parameter: destination - the Destination object to add
        public void AddDestination(Destination destination)
        {
            _context.Destinations.Add(destination);
            _context.SaveChanges();
        }

        // GetAllDestinations method - retrieves all destinations with their related travelers
        // Uses Include() to eagerly load the Travelers navigation property
        // This prevents N+1 query problems and ensures all related data is available
        public List<Destination> GetAllDestinations()
        {
            return _context.Destinations.Include(d => d.Travelers).ToList();
        }

        // GetDestinationByID method - finds a specific destination by ID
        // Returns null if no destination is found with the given ID
        // Includes related Travelers data to show which travelers are assigned to this destination
        // Parameter: id - the ID of the destination to find
        public Destination  GetDestinationByID(int id)
        {
            return _context.Destinations.Include(d => d.Travelers).FirstOrDefault(d => d.Id == id);
        }
    }
}
