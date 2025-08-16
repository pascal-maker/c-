// Define the namespace for media models
namespace media.models;

// Define the IMedia interface that all media types must implement
public interface IMedia
{  
    // Property to get the title of the media item (read-only)
    public string Title { get;}
    // Method that all media types must implement to define how they are consumed
    void Consume();
}