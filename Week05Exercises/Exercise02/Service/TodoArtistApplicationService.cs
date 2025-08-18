// Importeer System.Collections.Generic voor List<T> functionaliteit
using System.Collections.Generic;
// Importeer System.Threading.Tasks voor async/await functionaliteit
using System.Threading.Tasks;
// Importeer custom models voor Artist en Concert klassen
using Swagger.Models;
// Importeer custom repositories namespace
using Swagger.Repositories;

// Definieer de namespace voor service implementaties
namespace Swagger.Service
{
    // Definieer de TodoArtistApplicationService klasse die ITodoArtistApplicationService interface implementeert
    public class TodoArtistApplicationService :  ITodoArtistApplicationService
    {
        // Private readonly veld om de artiest repository dependency op te slaan
        private readonly IArtistRepository _artistRepository;

        // Constructor om de service te initialiseren met een nieuwe repository instantie
        public TodoArtistApplicationService()
        {
            // Maak een nieuwe ArtistRepository instantie voor data access
            _artistRepository = new ArtistRepository();
        }

        // Implementatie van GetAllArtists methode om alle artiesten op te halen
        public async Task<List<Artist>> GetAllArtists()
        {
            // Delegeer de call naar de repository en retourneer het resultaat
            return await _artistRepository.GetAllArtists();
        }

        // Implementatie van GetAllConcerts methode om alle concerten op te halen
         public async Task<List<Concert>> GetAllConcerts()
        {
            // Delegeer de call naar de repository en retourneer het resultaat
            return await _artistRepository.GetAllConcerts();
        }

        // Lege regel voor spacing

        // Lege regel voor spacing
        
        // Implementatie van GetConcertForArtist methode om concerten voor een specifieke artiest op te halen
        public async Task<List<Concert>> GetConcertForArtist(int ArtistID) 
        {
            // Delegeer de call naar de repository en retourneer het resultaat
            return await _artistRepository.GetConcertForArtist(ArtistID);
        }

        // Lege regel voor spacing
        
    }
}