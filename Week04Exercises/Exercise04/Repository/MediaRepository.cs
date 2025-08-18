// Import the media models namespace to use IMedia interface
using media.models;

// Define the namespace for media repositories
namespace media.Repositories
{
  // Define the MediaRepository class that implements IMediaRepository interface
  public class MediaRepository : IMediaRepository
  {
    // Private static readonly list to store all media items in memory
    private static readonly List<IMedia> _store = new();

    // Implementation of the Add method to add a new media item
    public void Add(IMedia media)
    {
      // Check if a media item with the same title already exists (case-insensitive)
      if (_store.Any(m => m.Title.Equals(media.Title, StringComparison.OrdinalIgnoreCase)))
        // Throw an exception if the title already exists
        throw new InvalidOperationException($"media with title'{media.Title} already exists");
      // Add the media item to the store if title is unique
      _store.Add(media);
    }

    // Empty line for spacing

    // Implementation of the Get method to retrieve a media item by title
    public IMedia Get(string title)
    {
      // Return null if the title is null, empty, or whitespace
      if (string.IsNullOrWhiteSpace(title)) return null;
      // Trim whitespace from the title
      var key = title.Trim();
      // Return the first media item that matches the title (case-insensitive)
      return _store.FirstOrDefault(m =>
      m.Title.Equals(key, StringComparison.OrdinalIgnoreCase));

      // Empty line for spacing

      // Empty line for spacing

    }

    // Implementation of the GetAll method to retrieve all media items
    public List<IMedia> GetAll()
    {
      // Return a new list containing all media items from the store
      return _store.ToList();
    }

    // Empty line for spacing

   }
}

// Empty line for spacing

// Empty line for spacing

// Empty line for spacing