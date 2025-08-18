// Importeer System.Collections.Generic voor List<T> functionaliteit
using System.Collections.Generic;
// Importeer System.Threading.Tasks voor async/await functionaliteit
using System.Threading.Tasks;
// Importeer custom models voor Artist en Concert klassen
using Swagger.Models;

// Definieer de namespace voor service interfaces
namespace Swagger.Service
{
    // Definieer de interface voor todo artiest applicatie service operaties
    public interface ITodoArtistApplicationService
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
    // Lege regel voor spacing

}
