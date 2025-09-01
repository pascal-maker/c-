
// Empty line for spacing

// Define the namespace for media models
namespace media.models;

/// <summary>
/// Series - Concrete implementatie van IMedia voor televisieseries
/// Representeert een serie met specifieke eigenschappen zoals aantal afleveringen en netwerk
/// Demonstreert inheritance en interface implementatie
/// </summary>
public class Series : IMedia
{
    /// <summary>
    /// Titel van de serie (implementatie van IMedia.Title)
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Aantal afleveringen in de serie
    /// </summary>
    public int NumberOfEpisodes { get; set; }

    /// <summary>
    /// Genre van de serie (bijv. "Drama", "Comedy", "Thriller")
    /// </summary>
    public string Genre { get; set; }

    /// <summary>
    /// Netwerk of platform dat de serie uitzendt (bijv. "Netflix", "HBO", "ABC")
    /// </summary>
    public string Creator { get; set; }

    /// <summary>
    /// Constructor voor het maken van een nieuwe Series
    /// Initialiseert alle properties met de opgegeven waarden
    /// </summary>
    /// <param name="title">Titel van de serie</param>
    /// <param name="numberofepisodes">Aantal afleveringen</param>
    /// <param name="genre">Genre van de serie</param>
    /// <param name="creator">Netwerk of platform</param>
    public Series(string title, int numberofepisodes, string genre, string creator)
    {
        // Wijs alle parameters toe aan de properties
        Title = title;
        NumberOfEpisodes = numberofepisodes;
        Genre = genre;
        Creator = creator;
    }

    /// <summary>
    /// Override van ToString() voor een leesbare string representatie
    /// Toont alle belangrijke eigenschappen van de serie
    /// </summary>
    /// <returns>Geformatteerde string met serie details</returns>
    public override string ToString()
    {
        return $"Title: {Title}, Number of Episodes: {NumberOfEpisodes}, Genre: {Genre}, Creator: {Creator}";
    }

    /// <summary>
    /// Implementatie van IMedia.Consume()
    /// Definieert hoe een serie wordt geconsumeerd (bekeken)
    /// </summary>
    public void Consume()
    {
        Console.WriteLine($"This Series is getting consumed");
    }
}