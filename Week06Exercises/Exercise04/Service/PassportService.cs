// Import required namespaces for models and repositories
using Exercise04.Models;
using Exercise04.Repositories;

// Namespace for service implementations
namespace Exercise04.Services
{
    // PassportService class - implements IPassportService interface
    // This class contains business logic for passport operations
    // Handles passport assignment, validation, and management for travelers
    // Coordinates between passport and traveler repositories
    public class PassportService : IPassportService
    {
        // Private fields to hold repository dependencies
        // Uses interfaces for loose coupling and dependency injection
        private readonly IPassportRepository _passportRepo;
        private readonly ITravelRepository _travelerRepo;

        // Constructor - dependency injection of passport and traveler repositories
        // This allows for loose coupling and easier testing
        public PassportService(IPassportRepository passportRepo, ITravelRepository travelerRepo)
        {
            _passportRepo = passportRepo;
            _travelerRepo = travelerRepo;
        }

        // AssignPassport method - assigns a passport to a specific traveler
        // Business logic: Validates traveler exists and passport number is valid
        // Parameters: travelerId - ID of the traveler to assign passport to
        //             passportNumber - the passport number to assign
        public void AssignPassport(int travelerId, string passportNumber)
        {
            // Validate that traveler exists
            var traveler = _travelerRepo.GetTravelerById(travelerId);
            if (traveler == null)
                throw new ArgumentException($"Traveler with ID {travelerId} not found");

            // Check if passport number is valid
            if (string.IsNullOrWhiteSpace(passportNumber))
                throw new ArgumentException("Passport number cannot be empty");

            // Delegate to repository to create the passport
            _passportRepo.AddPassport(travelerId, passportNumber);
        }

        // GetPassportByTravelerId method - retrieves passport for a specific traveler
        // Parameter: travelerId - ID of the traveler whose passport to find
        public Passport GetPassportByTravelerId(int travelerId)
        {
            return _passportRepo.GetPassportByTravelerId(travelerId);
        }

        // UpdatePassport method - updates passport number for a specific traveler
        // Business logic: Could add validation here if needed
        // Parameters: travelerId - ID of the traveler whose passport to update
        //             newPassportNumber - the new passport number
        public void UpdatePassport(int travelerId, string newPassportNumber)
        {
            // TODO: Add validation logic here if needed
            // For example: validate traveler exists, validate new passport number format

            _passportRepo.UpdatePassport(travelerId, newPassportNumber);
        }

        // RemovePassport method - removes passport from a specific traveler
        // Parameter: travelerId - ID of the traveler whose passport to remove
        public void RemovePassport(int travelerId)
        {
            _passportRepo.RemovePassport(travelerId);
        }

        // GetAllPassports method - retrieves all passports from the system
        // Returns complete list of all passport records
        public List<Passport> GetAllPassports()
        {
            return _passportRepo.GetAllPassports();
        }
    }
}
