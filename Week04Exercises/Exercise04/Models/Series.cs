
// Empty line for spacing

// Define the namespace for media models
namespace media.models;

// Define the Series class that implements the IMedia interface
public class Series : IMedia
{
    // Property to store the title of the series
    public string Title { get; set; }

    // Property to store the number of episodes in the series
    public int NumberOfEpisodes { get; set; }

    // Property to store the genre of the series
    public string Genre { get; set; }

    // Property to store the creator of the series
    public string Creator { get; set; }

    // Constructor to create a new Series object with all required properties
    public Series(string title, int numberofepisodes, string genre, string creator)
    {
        // Assign the title parameter to the Title property
        Title = title;
        // Assign the number of episodes parameter to the NumberOfEpisodes property
        NumberOfEpisodes = numberofepisodes;
        // Assign the genre parameter to the Genre property
        Genre = genre;
        // Assign the creator parameter to the Creator property
        Creator = creator;
    }

    // Override the ToString method to provide a custom string representation
    public override string ToString()
        {
            // Return a formatted string with all series details
            return $" Title: {Title},  Number of Episodes {NumberOfEpisodes}, Genre: {Genre},Creator:{Creator}";
        }

        // Empty line for spacing
        
        // Implementation of the Consume method from IMedia interface
        public void Consume()
        {
            // Display a message indicating the series is being consumed
            Console.WriteLine($"  This Serie is getting consumed");
        }

        // Empty line for spacing

        // Empty line for spacing

}