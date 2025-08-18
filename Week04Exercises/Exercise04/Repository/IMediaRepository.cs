// Import the media models namespace to use IMedia interface
using media.models;

// Define the namespace for media repositories
namespace media.Repositories;

// Empty line for spacing

// Define the interface for media repository operations
public interface IMediaRepository
{

     // Method to add a new media item to the repository
     void Add(IMedia media);

    // Method to get a media item by its title
    IMedia Get(string title);

    // Method to get all media items from the repository
    List<IMedia> GetAll();

    // Empty line for spacing

}
