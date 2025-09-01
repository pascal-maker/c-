
// Empty line for spacing

// Define the namespace for media models
namespace media.models;

/// <summary>
/// Movie - Concrete implementatie van IMedia voor films
/// Representeert een film met specifieke eigenschappen zoals duur, genre en regisseur
/// Demonstreert inheritance en interface implementatie
/// </summary>
public class Movie : IMedia
{
    /// <summary>
    /// Titel van de film (implementatie van IMedia.Title)
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Duur van de film in minuten
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Genre van de film (bijv. "Action", "Drama", "Comedy")
    /// </summary>
    public string Genre { get; set; }

    /// <summary>
    /// Regisseur van de film
    /// </summary>
    public string Director { get; set; }

    /// <summary>
    /// Constructor voor het maken van een nieuwe Movie
    /// Initialiseert alle properties met de opgegeven waarden
    /// </summary>
    /// <param name="title">Titel van de film</param>
    /// <param name="duration">Duur in minuten</param>
    /// <param name="genre">Genre van de film</param>
    /// <param name="director">Regisseur van de film</param>
    public Movie(string title, int duration, string genre, string director)
    {
        // Wijs alle parameters toe aan de properties
        Title = title;
        Duration = duration;
        Genre = genre;
        Director = director;
    }

    /// <summary>
    /// Override van ToString() voor een leesbare string representatie
    /// Toont alle belangrijke eigenschappen van de film
    /// </summary>
    /// <returns>Geformatteerde string met film details</returns>
    public override string ToString()
    {
        return $"Title: {Title}, Duration: {Duration}, Genre: {Genre}, Director: {Director}";
    }

    /// <summary>
    /// Implementatie van IMedia.Consume()
    /// Definieert hoe een film wordt geconsumeerd (bekeken)
    /// </summary>
    public void Consume()
    {
        Console.WriteLine($"This Movie is getting consumed");
    }
}