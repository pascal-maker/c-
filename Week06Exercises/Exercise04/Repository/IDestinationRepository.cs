using Exercise04.Models;
namespace Exercise04.Repositories
{
    public interface IDestinationRepository
{
    void AddDestination(Destination destination);
    List<Destination> GetAllDestinations();
    Destination GetDestinationByID(int id);
    }
}
