// Import required namespaces for models and repositories
using Exercise04.Models;
using Exercise04.Repositories;

// Namespace for service implementations
namespace Exercise04.Services
{
    // GuideService class - implements IGuideService interface
    // This class contains business logic for guide operations
    // Handles guide creation and retrieval operations
    // Acts as an intermediary between the presentation layer and repository layer
    public class GuideService : IGuideService
    {
        // Private field to hold the guide repository
        // Uses interface for loose coupling and dependency injection
        private readonly IGuideRepository _guideRepo;

        // Constructor - dependency injection of IGuideRepository
        // This allows for loose coupling and easier testing
        public GuideService(IGuideRepository guideRepo)
        {
            _guideRepo = guideRepo;
        }

        // AddGuide method - creates a new guide with the provided name
        // Business logic: Creates Guide object and delegates to repository
        // Parameter: name - the name of the guide to create
        public void AddGuide(string name)
        {
            var guide = new Guide { Name = name };
            _guideRepo.AddGuide(guide);
        }

        // GetAllGuides method - retrieves all guides from the repository
        // Returns the complete list of guides with their related tours data
        public List<Guide> GetAllGuides()
        {
            return _guideRepo.GetAllGuides();
        }
    }
}