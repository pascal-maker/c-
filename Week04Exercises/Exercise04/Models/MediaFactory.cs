// Define the namespace for media models
namespace media.models;

/// <summary>
/// MediaFactory - Factory klasse voor het maken van verschillende media objecten
/// Gebruikt parameters in plaats van hardcoded waarden voor flexibiliteit
/// </summary>
public static class MediaFactory
{
    /// <summary>
    /// Maakt een Movie object met de opgegeven parameters
    /// </summary>
    /// <param name="title">Titel van de film</param>
    /// <param name="duration">Duur in minuten</param>
    /// <param name="genre">Genre van de film</param>
    /// <param name="director">Regisseur van de film</param>
    /// <returns>Nieuw Movie object</returns>
    public static IMedia CreateMovie(string title, int duration, string genre, string director)
    {
        return new Movie(title, duration, genre, director);
    }

    /// <summary>
    /// Maakt een Podcast object met de opgegeven parameters
    /// </summary>
    /// <param name="title">Titel van de podcast</param>
    /// <param name="duration">Duur in minuten</param>
    /// <param name="host">Host van de podcast</param>
    /// <returns>Nieuw Podcast object</returns>
    public static IMedia CreatePodcast(string title, int duration, string host)
    {
        return new Podcast(title, duration, host);
    }

    /// <summary>
    /// Maakt een Series object met de opgegeven parameters
    /// </summary>
    /// <param name="title">Titel van de serie</param>
    /// <param name="episodes">Aantal afleveringen</param>
    /// <param name="genre">Genre van de serie</param>
    /// <param name="network">Netwerk dat de serie uitzendt</param>
    /// <returns>Nieuw Series object</returns>
    public static IMedia CreateSeries(string title, int episodes, string genre, string network)
    {
        return new Series(title, episodes, genre, network);
    }

    /// <summary>
    /// Maakt een media object op basis van type en parameters
    /// Flexibele methode die user input kan accepteren
    /// </summary>
    /// <param name="mediaType">Type media ("movie", "podcast", "series")</param>
    /// <param name="parameters">Dictionary met parameters voor het media object</param>
    /// <returns>Nieuw media object</returns>
    public static IMedia Create(string mediaType, Dictionary<string, object> parameters)
    {
        switch (mediaType.ToLower())
        {
            case "movie":
                return CreateMovie(
                    (string)parameters["title"],
                    (int)parameters["duration"],
                    (string)parameters["genre"],
                    (string)parameters["director"]
                );
            
            case "podcast":
                return CreatePodcast(
                    (string)parameters["title"],
                    (int)parameters["duration"],
                    (string)parameters["host"]
                );
            
            case "series":
                return CreateSeries(
                    (string)parameters["title"],
                    (int)parameters["episodes"],
                    (string)parameters["genre"],
                    (string)parameters["network"]
                );
            
            default:
                throw new ArgumentException($"Unknown media type: {mediaType}");
        }
    }

    /// <summary>
    /// Maakt een media object met user input
    /// Vraagt gebruiker om alle benodigde informatie
    /// </summary>
    /// <param name="mediaType">Type media om te maken</param>
    /// <returns>Nieuw media object met user input</returns>
    public static IMedia CreateWithUserInput(string mediaType)
    {
        Console.WriteLine($"\n=== Creating new {mediaType} ===");
        
        switch (mediaType.ToLower())
        {
            case "movie":
                Console.Write("Enter movie title: ");
                string movieTitle = Console.ReadLine() ?? "";
                Console.Write("Enter duration (minutes): ");
                int movieDuration = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter genre: ");
                string movieGenre = Console.ReadLine() ?? "";
                Console.Write("Enter director: ");
                string movieDirector = Console.ReadLine() ?? "";
                
                return CreateMovie(movieTitle, movieDuration, movieGenre, movieDirector);
            
            case "podcast":
                Console.Write("Enter podcast title: ");
                string podcastTitle = Console.ReadLine() ?? "";
                Console.Write("Enter duration (minutes): ");
                int podcastDuration = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter host: ");
                string podcastHost = Console.ReadLine() ?? "";
                
                return CreatePodcast(podcastTitle, podcastDuration, podcastHost);
            
            case "series":
                Console.Write("Enter series title: ");
                string seriesTitle = Console.ReadLine() ?? "";
                Console.Write("Enter number of episodes: ");
                int seriesEpisodes = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter genre: ");
                string seriesGenre = Console.ReadLine() ?? "";
                Console.Write("Enter network: ");
                string seriesNetwork = Console.ReadLine() ?? "";
                
                return CreateSeries(seriesTitle, seriesEpisodes, seriesGenre, seriesNetwork);
            
            default:
                throw new ArgumentException($"Unknown media type: {mediaType}");
        }
    }
}