using Exercise04.Models;
using Exercise04.Repositories;
namespace Exercise04.Services
{
    public class GuideService : IGuideService
    {
        private readonly IGuideRepository _guideRepo;

        public GuideService(IGuideRepository guideRepo)
        {
            _guideRepo = guideRepo;
        }

        public void AddGuide(string name)
        {
            var guide = new Guide { Name = name };
            _guideRepo.AddGuide(guide);
        }

        public List<Guide> GetAllGuides()
        {
            return _guideRepo.GetAllGuides();
        }
    }
}