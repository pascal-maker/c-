namespace media.models;

/// <summary>
/// MediaFactory - Centrale plek om IMedia objecten te maken.
/// Biedt meerdere overloads:
/// - CreateMovie/CreatePodcast/CreateSeries: expliciete parameters (duidelijk en type-safe)
/// - Create(string, Dictionary<string, object>): flexibele aanroep met key/value parameters
/// - CreateWithUserInput(string): interactieve aanmaak via console input
/// </summary>
public static class MediaFactory
{
    /// <summary>
    /// Maakt een <see cref="Movie"/> met expliciete parameters.
    /// </summary>
    /// <param name="title">Titel van de film</param>
    /// <param name="duration">Duur in minuten</param>
    /// <param name="genre">Genre (bijv. "Sci-Fi")</param>
    /// <param name="director">Regisseur</param>
    /// <returns>Nieuw <see cref="IMedia"/> (Movie)</returns>
    public static IMedia CreateMovie(string title,int duration,string genre,string director)
    {
        // Type-safe constructie van een Movie
        return new Movie(title,duration,genre,director);
    }

    /// <summary>
    /// Maakt een <see cref="Podcast"/> met expliciete parameters.
    /// </summary>
    /// <param name="title">Titel van de podcast</param>
    /// <param name="duration">Duur in minuten</param>
    /// <param name="host">Host/presentator</param>
    /// <returns>Nieuw <see cref="IMedia"/> (Podcast)</returns>
    public static IMedia CreatePodcast(string title,int duration,string host)
    {
        // Type-safe constructie van een Podcast
        return new Podcast(title,duration,host);
    }

    /// <summary>
    /// Maakt een <see cref="Series"/> met expliciete parameters.
    /// </summary>
    /// <param name="title">Titel van de serie</param>
    /// <param name="episodes">Aantal afleveringen</param>
    /// <param name="genre">Genre (bijv. "Drama")</param>
    /// <param name="network">Netwerk/platform</param>
    /// <returns>Nieuw <see cref="IMedia"/> (Series)</returns>
    public static IMedia CreateSeries(string title,int episodes,string genre,string network)
    {
        // Type-safe constructie van een Series
        return new Series(title,episodes,genre,network);
    }

    /// <summary>
    /// Maakt een media object op basis van een type en een parameters-woordenboek.
    /// Handig wanneer parameters dynamisch aangeleverd worden (bijv. UI of JSON).
    /// Vereist dat vereiste keys aanwezig zijn in <paramref name="parameters"/>.
    /// </summary>
    /// <param name="mediaType">"movie", "podcast" of "series" (case-insensitive)</param>
    /// <param name="parameters">Benodigde velden per type (title, duration, ...)</param>
    /// <returns>Nieuw <see cref="IMedia"/> object</returns>
    /// <exception cref="ArgumentException">Wanneer het type onbekend is</exception>
    public static IMedia Create(string mediaType,Dictionary<string,object> parameters)
    {
        // Normaliseer type zodat switch case-insensitive is
        switch (mediaType.ToLower())
        {
            case "movie":
                // Verwachte keys: title (string), duration (int), genre (string), director (string)
                return  CreateMovie((string) parameters["title"],
                (int) parameters ["duration"],
                (string) parameters["genre"],
                (string) parameters["director"]);

            case "podcast":
                // Verwachte keys: title (string), duration (int), host (string)
                return  CreatePodcast(
                (string) parameters["title"],
                (int) parameters ["duration"],
                (string) parameters["host"]
              );

            case "series":
                // Verwachte keys: title (string), episodes (int), genre (string), network (string)
                return  CreateSeries(
                (string) parameters["title"],
                (int) parameters ["episodes"],
                (string) parameters["genre"],
                (string) parameters["network"]

              );

            default:
                // Onbekend type → duidelijke foutmelding
                throw  new ArgumentException($"Unknown media type: {mediaType}");
        }
    }

    /// <summary>
    /// Interactieve media creatie via de console. Vraagt gebruiker om alle velden.
    /// Handig voor demo's of eenvoudige CLI-applicaties.
    /// </summary>
    /// <param name="mediaType">"movie", "podcast" of "series" (case-insensitive)</param>
    /// <returns>Nieuw <see cref="IMedia"/> object</returns>
    /// <exception cref="ArgumentException">Wanneer het type onbekend is</exception>
    public static IMedia CreateWithUserInput(string mediaType)
    {
        Console.WriteLine($"\n === Creating new {mediaType}");

        // Case-insensitive routing naar juiste input-flow
        switch (mediaType.ToLower())
        {
            case "movie":
                Console.Write("Enter  movie title:");
                string movieTitle = Console.ReadLine() ?? "";
                Console.Write("Enter  duration minutes:");
                int movieDuration = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter  Genre:");
                string  movieGenre = Console.ReadLine() ?? "";
                Console.Write("Enter Director:");
                string  movieDirector = Console.ReadLine() ?? "";

                return CreateMovie(movieTitle,movieDuration,movieGenre,movieDirector);

            case "podcast":
                Console.Write("Enter  podcast title:");
                string podcastTitle = Console.ReadLine() ?? "";
                Console.Write("Enter  duration minutes:");
                int podcastDuration = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter  Host:");
                string  podcastHost= Console.ReadLine() ?? "";

                return CreatePodcast(podcastTitle,podcastDuration,podcastHost);

            case "series":
                Console.Write("Enter  series title:");
                string seriesTitle = Console.ReadLine() ?? "";
                Console.Write("Enter  number of  episodes:");
                int seriesEpisodes= int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter  Genre:");
                string  seriesGenre = Console.ReadLine() ?? "";
                Console.Write("Enter network:");
                string  seriesNetwork = Console.ReadLine() ?? "";

                return CreateSeries(seriesTitle,seriesEpisodes,seriesGenre,seriesNetwork);

            default:
                // Onbekend type → duidelijke foutmelding
                throw new ArgumentException($" unknown media type{mediaType}")  ;
        }
    }
}