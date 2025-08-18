using Exercise04.Models;
namespace Exercise04.Repositories
{
    public interface ITourRepository
{
    void AddTour(Tour tour);
    List<Tour> GetAllTours();
    Tour GetTourById(int id);
    }
}
