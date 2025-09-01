// Import the System.Runtime.CompilerServices namespace for compiler services
using System.Runtime.CompilerServices;
// Import the media models namespace to use media classes
using media.models;
// Import the media repositories namespace to use repository classes
using media.Repositories;
// Import the media services namespace to use service classes
using media.Services;

/// <summary>
/// Movies - Hoofdklasse voor de Media Management System applicatie
/// Demonstreert het gebruik van Factory Pattern, Repository Pattern en Service Layer
/// Toont verschillende manieren om media objecten te maken en te beheren
/// </summary>
class Movies
{
    /// <summary>
    /// Main methode - Entry point van de applicatie
    /// Demonstreert de volledige functionaliteit van het Media Management System
    /// </summary>
    static void Main()
    {
        // Setup van dependencies (Dependency Injection)
        var repo = new MediaRepository();
        var service = new MediaService(repo);

        Console.WriteLine("=== Media Management System ===\n");

        // Demo 1: Media maken met specifieke parameters (geen hardcoded waarden!)
        Console.WriteLine("1. Creating media with specific parameters:");
        var m1 = MediaFactory.CreateMovie("The Matrix", 136, "Sci-Fi", "Wachowski Sisters");
        var s1 = MediaFactory.CreateSeries("Breaking Bad", 62, "Drama", "AMC");
        var p1 = MediaFactory.CreatePodcast("The Joe Rogan Experience", 180, "Joe Rogan");

        // Demo 2: Media maken met Dictionary parameters
        Console.WriteLine("\n2. Creating media with Dictionary parameters:");
        var movieParams = new Dictionary<string, object>
        {
            ["title"] = "Inception",
            ["duration"] = 148,
            ["genre"] = "Sci-Fi",
            ["director"] = "Christopher Nolan"
        };
        var m2 = MediaFactory.Create("movie", movieParams);

        // Demo 3: Media maken met user input (interactief)
        Console.WriteLine("\n3. Creating media with user input:");
        Console.Write("What type of media do you want to create? (movie/podcast/series): ");
        string userChoice = Console.ReadLine()?.ToLower() ?? "movie";
        
        IMedia userMedia = null;
        try
        {
            // Gebruik de interactieve factory methode
            userMedia = MediaFactory.CreateWithUserInput(userChoice);
            Console.WriteLine(" Media created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating media: {ex.Message}");
        }

        // Voeg alle media toe aan de service
        service.Add(m1);
        service.Add(m2);
        service.Add(s1);
        service.Add(p1);
        if (userMedia != null)
        {
            service.Add(userMedia);
        }

        // Toon alle media items
        Console.WriteLine("\n=== All media ===");
        service.GetAll().ForEach(Console.WriteLine);

        // Demo zoekfunctionaliteit
        Console.WriteLine("\n=== Search by title ===");
        Console.Write("Enter title to search for: ");
        string searchTitle = Console.ReadLine() ?? "";
        var found = service.GetByTitle(searchTitle);
        Console.WriteLine(found is null ? " Not found" : $" Found: {found}");

        // Demo consume functionaliteit
        if (found != null)
        {
            Console.WriteLine("\n=== Consuming media ===");
            found.Consume();
        }

        Console.WriteLine("\n=== Program finished ===");
    }
}
