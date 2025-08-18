// Define the namespace for media models
namespace media.models;

// Define a static factory class for creating different types of media objects
public static class MediaFactory
{
    // Static method to create media objects based on the media type string
    public static IMedia Create(string mediaType)
    {
        // Switch statement to handle different media types (case-insensitive)
        switch (mediaType.ToLower())
        {
            // Create and return a new Movie object with predefined values
            case "movie": return new Movie("harrypotter", 120, "sky-fi", "jamescameron");
            // Create and return a new Podcast object with predefined values
            case "podcast": return new Podcast("joeroganpodcast", 240, "joerogan");
            // Create and return a new Series object with predefined values
            case "series": return new Series("prisonbreak", 250, "drama", "fox");
            // Throw an exception for unknown media types
            default: throw new ArgumentException("Unknown media type");

            // Empty line for spacing

        }
    }
}