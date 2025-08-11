using Exercise04.Models;
namespace Exercise04.Repositories
{
    public interface IGuideRepository
    {
        void AddGuide(Guide guide);
        List<Guide> GetAllGuides();
        Guide GetGuideById(int id);
    }
}