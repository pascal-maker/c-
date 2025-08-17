// Import required namespaces for models and repositories
using Exercise04.Models;
using Exercise04.Repositories;

// Namespace for service implementations
namespace Exercise04.Services
{
    // TourService class - implements ITourService interface
    // This class contains business logic for tour operations
    // Handles tour creation and retrieval operations
    // Manages the relationship between tours and guides
    public class TourService : ITourService
    {
        // Private field to hold the tour repository
        // Uses interface for loose coupling and dependency injection
        private readonly ITourRepository _tourRepo;

        // Constructor - dependency injection of ITourRepository
        // This allows for loose coupling and easier testing
        public TourService(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
        }

        // AddTour method - creates a new tour with the provided title and guide
        // Business logic: Creates Tour object with guide assignment and delegates to repository
        // Parameters: title - the title of the tour to create
        //             guideId - the ID of the guide to assign to this tour
        public void AddTour(string title, int guideId)
        {
            var tour = new Tour { Title = title, GuideId = guideId };
            _tourRepo.AddTour(tour);
        }

        // GetAllTours method - retrieves all tours from the repository
        // Returns the complete list of tours with their related guide data
        public List<Tour> GetAllTours()
        {
            return _tourRepo.GetAllTours();
        }
    }
}