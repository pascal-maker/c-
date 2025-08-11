using Exercise04.Models;
namespace Exercise04.Services
{
    public interface ITourService
{
    void AddTour(string title,int guideId);
    List<Tour> GetAllTours();

    }
}
