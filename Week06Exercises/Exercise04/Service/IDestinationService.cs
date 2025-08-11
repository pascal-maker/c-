using Exercise04.Models;
namespace Exercise04.Services
{
    public interface IDestinationService
{
    void AddDestination(string name);
    List<Destination> GetAllDestinations();

    }
}
