
// Empty line for spacing

// Define the namespace for media models
namespace media.models;

// Define the Movie class that implements the IMedia interface
public class Movie : IMedia
{
    // Property to store the title of the movie
    public string Title { get; set; }

    // Property to store the duration of the movie in minutes
    public int Duration { get; set; }

    // Property to store the genre of the movie
    public string Genre { get; set; }

    // Property to store the director of the movie
    public string Director { get; set; }

    // Constructor to create a new Movie object with all required properties
    public Movie(string title, int duration, string genre, string director)
    {
        // Assign the title parameter to the Title property
        Title = title;
        // Assign the duration parameter to the Duration property
        Duration = duration;
        // Assign the genre parameter to the Genre property
        Genre = genre;
        // Assign the director parameter to the Director property
        Director = director;
    }

    // Override the ToString method to provide a custom string representation
    public override string ToString()
        {
            // Return a formatted string with all movie details
            return $" Title: {Title},  Duration {Duration}, Genre: {Genre},Director:{Director}";
        }

        // Empty line for spacing
        
        // Implementation of the Consume method from IMedia interface
        public void Consume()
        {
            // Display a message indicating the movie is being consumed
            Console.WriteLine($"  This Movie is getting consumed");
        }

        // Empty line for spacing

        // Empty line for spacing

}