// Define the namespace for media models
namespace media.models;

/// <summary>
/// IMedia - Interface voor alle media types in het systeem
/// Definieert het contract dat alle media objecten moeten implementeren
/// Volgt het Interface Segregation Principle van SOLID
/// </summary>
public interface IMedia
{  
    /// <summary>
    /// Titel van het media item (read-only property)
    /// Alle media types moeten een titel hebben voor identificatie
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Methode die alle media types moeten implementeren
    /// Definieert hoe het media item wordt geconsumeerd/gebruikt
    /// Elke media type kan zijn eigen implementatie hebben
    /// </summary>
    void Consume();
}