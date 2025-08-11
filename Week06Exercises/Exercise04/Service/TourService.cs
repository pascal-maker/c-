using Exercise04.Models;
using Exercise04.Repositories;
namespace Exercise04.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepo;

        public TourService(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
        }

        public void AddTour(string title, int guideId)
        {
            var tour = new Tour { Title = title,GuideId = guideId };
            _tourRepo.AddTour(tour);
        }

        public List<Tour> GetAllTours()
        {
            return _tourRepo.GetAllTours();
        }
    }
}