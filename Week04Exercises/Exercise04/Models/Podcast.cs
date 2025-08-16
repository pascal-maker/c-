
// Empty line for spacing

// Define the namespace for media models
namespace media.models;

// Define the Podcast class that implements the IMedia interface
public class Podcast : IMedia
{
    // Property to store the title of the podcast
    public string Title { get; set; }

    // Property to store the number of episodes in the podcast
    public int NumberOfEpisodes { get; set; }

    // Property to store the host of the podcast
    public string Host { get; set; }

    // Empty line for spacing

    // Constructor to create a new Podcast object with all required properties
    public Podcast(string title, int numberofepisodes, string host)
    {
        // Assign the title parameter to the Title property
        Title = title;
        // Assign the number of episodes parameter to the NumberOfEpisodes property
        NumberOfEpisodes = numberofepisodes;
        // Assign the host parameter to the Host property
        Host= Host;
        
        // Empty line for spacing
    }

    // Override the ToString method to provide a custom string representation
    public override string ToString()
        {
            // Return a formatted string with all podcast details
            return $" Title: {Title},  NumberOfEpisodes {NumberOfEpisodes},Host {Host}";
        }

        // Empty line for spacing
        
        // Implementation of the Consume method from IMedia interface
        public void Consume()
        {
            // Display a message indicating the podcast is being consumed
            Console.WriteLine($"  ThisPocast is getting consumed");
        }

        // Empty line for spacing

        // Empty line for spacing

}