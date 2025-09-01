// Import the media models namespace to use IMedia interface
using media.models;

// Define the namespace for media repositories
namespace media.Repositories;

/// <summary>
/// IMediaRepository - Interface voor data toegang van media objecten
/// Definieert het contract voor alle repository implementaties
/// Volgt het Repository Pattern voor scheiding van data toegang en business logic
/// </summary>
public interface IMediaRepository
{
    /// <summary>
    /// Voegt een nieuw media item toe aan de repository
    /// </summary>
    /// <param name="media">Het media object om toe te voegen</param>
    void Add(IMedia media);

    /// <summary>
    /// Haalt een media item op basis van titel op
    /// </summary>
    /// <param name="title">Titel van het media item om te zoeken</param>
    /// <returns>Media object of null als niet gevonden</returns>
    IMedia Get(string title);

    /// <summary>
    /// Haalt alle media items op uit de repository
    /// </summary>
    /// <returns>Lijst van alle media objecten</returns>
    List<IMedia> GetAll();
}
