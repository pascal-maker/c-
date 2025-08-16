// Import the System.Runtime.CompilerServices namespace for compiler services
using System.Runtime.CompilerServices;
// Import the media models namespace to use IMedia interface
using media.models;
// Import the media repositories namespace to use IMediaRepository interface
using media.Repositories;
// Define the namespace for media services
namespace media.Services
{
    // Define the MediaService class to handle business logic for media operations
    public class MediaService
    {
        // Private readonly field to store the repository dependency
        private readonly IMediaRepository _repo;

        // Constructor to initialize the service with a repository (dependency injection)
        public MediaService(IMediaRepository repo)
        {
            // Assign the provided repository to the private field
            _repo = repo;
        }

        // Method to add a new media item with validation
        public void Add(IMedia media)
        {
            // Validate that the media title is not null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(media.Title))
                // Throw an exception if the title is invalid
                throw new ArgumentException("Title is required");
            // Add the media item to the repository if validation passes
            _repo.Add(media);

            // Empty line for spacing
        }

        // Empty line for spacing

        // Method to get a media item by title with validation
        public IMedia GetByTitle(string title)
        {
            // Return null if the title is null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(title)) return null;
            // Get the media item from the repository
            return _repo.Get(title);

            // Empty line for spacing
        }

        // Empty line for spacing

        // Method to get all media items
        public List<IMedia> GetAll()
        {
            // Return all media items from the repository
            return _repo.GetAll();
        }

        // Empty line for spacing

    }
}
