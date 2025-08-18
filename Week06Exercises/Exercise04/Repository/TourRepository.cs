// Import required namespaces for Entity Framework Core and data access
using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;

// Namespace for repository implementations
namespace Exercise04.Repositories
{
    // TourRepository class - implements ITourRepository interface
    // This class handles all database operations related to tours
    // Manages the one-to-many relationship between guides and tours
    public class TourRepository : ITourRepository
    {
        // Private field to hold the database context
        // readonly ensures this field can only be set in the constructor
        private readonly AppDbContext _context;

        // Constructor - dependency injection of AppDbContext
        // This allows for loose coupling and easier testing
        public TourRepository(AppDbContext context)
        {
            _context = context;
        }

        // AddTour method - adds a new tour to the database
        // Saves changes immediately to persist the new tour
        // Parameter: tour - the Tour object to add
        public void AddTour(Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }

        // GetAllTours method - retrieves all tours with their related guides
        // Uses Include() to eagerly load the Guide navigation property
        // This prevents N+1 query problems and ensures all related data is available
        public List<Tour> GetAllTours()
        {
            return _context.Tours.Include(t => t.Guide).ToList();
        }

        // GetTourById method - finds a specific tour by ID
        // Returns null if no tour is found with the given ID
        // Includes related Guide data to show which guide is assigned to this tour
        // Parameter: id - the ID of the tour to find
        public Tour  GetTourById(int id)
        {
            return _context.Tours.Include(t => t.Guide).FirstOrDefault(t => t.Id == id);
        }
    }
}