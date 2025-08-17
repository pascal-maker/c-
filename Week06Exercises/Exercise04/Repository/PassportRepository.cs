// Import required namespaces for Entity Framework Core and data access
using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;

// Namespace for repository implementations
namespace Exercise04.Repositories
{
    // PassportRepository class - implements IPassportRepository interface
    // This class handles all database operations related to passports
    // Manages the one-to-one relationship between travelers and passports
    public class PassportRepository : IPassportRepository
    {
        // Private field to hold the database context
        // readonly ensures this field can only be set in the constructor
        private readonly AppDbContext _context;

        // Constructor - dependency injection of AppDbContext
        // This allows for loose coupling and easier testing
        public PassportRepository(AppDbContext context)
        {
            _context = context;
        }

        // AddPassport method - creates a new passport and assigns it to a traveler
        // Creates a one-to-one relationship between traveler and passport
        // Parameters: travelerId - ID of the traveler to assign the passport to
        //             passportNumber - the passport number for the new passport
        public void AddPassport(int travelerId, string passportNumber)
        {
            // Find the traveler by ID
            var traveler = _context.Travellers.FirstOrDefault(t => t.Id == travelerId);
           
            // Create new passport object with the provided data
            var passport = new Passport
            {
                PassportNumber = passportNumber,
                Traveler = traveler
            };
            
            // Add passport to database and save changes
            _context.Passport.Add(passport);
            _context.SaveChanges();
        }

        // GetAllPassports method - retrieves all passports from the database
        // Returns a list of all passport records
        public List<Passport> GetAllPassports()
        {
            return _context.Passport.ToList();
        }

        // GetById method - finds a specific passport by its ID
        // Returns null if no passport is found with the given ID
        public Passport GetById(int id)
        {
            return _context.Passport.FirstOrDefault(p => p.Id == id);
        }

        // GetPassportByTravelerId method - finds a passport by traveler ID
        // Uses the one-to-one relationship to find the passport for a specific traveler
        // Returns null if no passport is found for the given traveler
        public Passport GetPassportByTravelerId(int travelerId)
        {
            return _context.Passport.FirstOrDefault(p => p.Traveler.Id == travelerId);
        }

        // UpdatePassport method - updates the passport number for a specific traveler
        // Finds the passport by traveler ID and updates the passport number
        // Parameters: travelerId - ID of the traveler whose passport to update
        //             newPassportNumber - the new passport number
        public void UpdatePassport(int travelerId, string newPassportNumber)
        {
            var passport = _context.Passport.FirstOrDefault(p => p.Traveler.Id == travelerId);
            passport.PassportNumber = newPassportNumber;
            _context.SaveChanges();
        }

        // RemovePassport method - removes a passport from a traveler
        // Deletes the passport record from the database
        // Parameter: travelerId - ID of the traveler whose passport to remove
        public void RemovePassport(int travelerId)
        {
            var passport = _context.Passport.FirstOrDefault(p => p.Traveler.Id == travelerId);
            _context.Passport.Remove(passport);
            _context.SaveChanges();
        }
    }
}       