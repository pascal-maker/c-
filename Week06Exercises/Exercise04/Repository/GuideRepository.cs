// Import required namespaces for Entity Framework Core and data access
using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;

// Namespace for repository implementations
namespace Exercise04.Repositories
{
    // GuideRepository class - implements IGuideRepository interface
    // This class handles all database operations related to guides
    // Manages the one-to-many relationship between guides and tours
    public class GuideRepository : IGuideRepository
    {
        // Private field to hold the database context
        // readonly ensures this field can only be set in the constructor
        private readonly AppDbContext _context;

        // Constructor - dependency injection of AppDbContext
        // This allows for loose coupling and easier testing
        public GuideRepository(AppDbContext context)
        {
            _context = context;
        }

        // AddGuide method - adds a new guide to the database
        // Saves changes immediately to persist the new guide
        // Parameter: guide - the Guide object to add
        public void AddGuide(Guide guide)
        {
            _context.Guide.Add(guide);
            _context.SaveChanges();
        }

        // GetAllGuides method - retrieves all guides with their related tours
        // Uses Include() to eagerly load the Tours navigation property
        // This prevents N+1 query problems and ensures all related data is available
        public List<Guide> GetAllGuides()
        {
            return _context.Guide.Include(g => g.Tours).ToList();
        }

        // GetGuideById method - finds a specific guide by ID
        // Returns null if no guide is found with the given ID
        // Includes related Tours data to show which tours the guide is assigned to
        // Parameter: id - the ID of the guide to find
        public Guide  GetGuideById(int id)
        {
            return _context.Guide.Include(g => g.Tours).FirstOrDefault(g => g.Id == id);
        }
    }
}