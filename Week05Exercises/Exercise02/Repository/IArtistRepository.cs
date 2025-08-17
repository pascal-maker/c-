// Importeer de models namespace om Artist en Concert klassen te gebruiken
using Swagger.Models;
// Importeer de repositories namespace voor interface definitie
using Swagger.Repositories;
// Definieer de namespace voor repository interfaces
namespace Swagger.Repositories;
// Definieer de interface voor artiest repository operaties
public interface IArtistRepository
{
    // Methode om alle artiesten asynchroon op te halen
    Task<List<Artist>> GetAllArtists();

    // Methode om alle concerten asynchroon op te halen
    Task<List<Concert>> GetAllConcerts();

    // Lege regel voor spacing

    // Lege regel voor spacing

    // Methode om alle concerten voor een specifieke artiest asynchroon op te halen
    Task<List<Concert>> GetConcertForArtist(int ArtistID);

}
