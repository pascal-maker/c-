// Import the System.Runtime.CompilerServices namespace for compiler services
using System.Runtime.CompilerServices;
// Import the media models namespace to use media classes
using media.models;
// Import the media repositories namespace to use repository classes
using media.Repositories;
// Import the media services namespace to use service classes
using media.Services;

// Define the Movies class to contain the main program
class Movies
{
    // Define the main entry point of the application
    static void Main()
    {
        // Create a new instance of MediaRepository for data storage
        var repo = new MediaRepository();
        // Create a new instance of MediaService and inject the repository
        var service = new MediaService(repo);

        // Create a movie using the MediaFactory
        var m1 = MediaFactory.Create("movie");
        // Create a series using the MediaFactory
        var s1 = MediaFactory.Create("series");
        // Create a podcast using the MediaFactory
        var p1 = MediaFactory.Create("podcast");

        // Create a movie directly using the Movie constructor
        var m2 = new Movie("dune", 155, "Sci-fi", "dennis villeneuve");

        // Add the factory-created movie to the service
        service.Add(m1);
        // Add the directly created movie to the service
        service.Add(m2);
        // Add the series to the service
        service.Add(s1);
        // Add the podcast to the service
        service.Add(p1);

        // Display a header for all media items
        Console.WriteLine("=== All media ===");
        // Get all media items and display each one using ForEach
        service.GetAll().ForEach(Console.WriteLine);

        // Empty line for spacing

        // Display a header for fetching by title
        Console.WriteLine("\n Fetcch by title===");
        // Search for media with title "dune"
        var found = service.GetByTitle("dune");
        // Display the found media or "not found" if null
        Console.WriteLine(found is null ? "not found" : found.ToString());

        // Display a header for consuming media
        Console.WriteLine("\n== Consume one");
        // Call the Consume method on the found media item
        found.Consume();

        // Empty lines for spacing

        // Empty lines for spacing

        // Empty lines for spacing

    }
}
