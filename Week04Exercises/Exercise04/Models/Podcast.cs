
// Empty line for spacing

// Define the namespace for media models
namespace media.models;

/// <summary>
/// Podcast - Concrete implementatie van IMedia voor podcasts
/// Representeert een podcast met specifieke eigenschappen zoals host en aantal afleveringen
/// Demonstreert inheritance en interface implementatie
/// </summary>
public class Podcast : IMedia
{
    /// <summary>
    /// Titel van de podcast (implementatie van IMedia.Title)
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Aantal afleveringen in de podcast
    /// </summary>
    public int NumberOfEpisodes { get; set; }

    /// <summary>
    /// Host of presentator van de podcast
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// Constructor voor het maken van een nieuwe Podcast
    /// Initialiseert alle properties met de opgegeven waarden
    /// </summary>
    /// <param name="title">Titel van de podcast</param>
    /// <param name="numberofepisodes">Aantal afleveringen</param>
    /// <param name="host">Host van de podcast</param>
    public Podcast(string title, int numberofepisodes, string host)
    {
        // Wijs alle parameters toe aan de properties
        Title = title;
        NumberOfEpisodes = numberofepisodes;
        Host = host;  // Fix: was Host= Host (bug)
    }

    /// <summary>
    /// Override van ToString() voor een leesbare string representatie
    /// Toont alle belangrijke eigenschappen van de podcast
    /// </summary>
    /// <returns>Geformatteerde string met podcast details</returns>
    public override string ToString()
    {
        return $"Title: {Title}, NumberOfEpisodes: {NumberOfEpisodes}, Host: {Host}";
    }

    /// <summary>
    /// Implementatie van IMedia.Consume()
    /// Definieert hoe een podcast wordt geconsumeerd (beluisterd)
    /// </summary>
    public void Consume()
    {
        Console.WriteLine($"This Podcast is getting consumed");
    }
}