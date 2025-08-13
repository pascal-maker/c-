using Exercise04.Models;
namespace Exercise04.Services
{
    public interface IGuideService
{
    void AddGuide(string name);
    List<Guide> GetAllGuides();

    }
}
