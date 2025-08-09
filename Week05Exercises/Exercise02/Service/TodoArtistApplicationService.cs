using System.Collections.Generic;     // Voor List<T>
using System.Threading.Tasks;         // Voor Task<>
using Ct.Ai.Models;                   // Voor Post en Comment
using Ct.Ai.Repositories;             // Voor IPostRepository en PostRepository
using Ct.Ai.Service;                   // Voor ITodoApplicationService

namespace Ct.Ai.Service
{
    /// <summary>
    /// De concrete implementatie van ITodoApplicationService.
    /// Deze service praat met de PostRepository om data op te halen of te versturen.
    /// </summary>
    public class TodoArtistApplicationService : ITodoArtistApplicationService
    {
        // Veld dat verwijst naar de repository voor Artist.
        private readonly IArtistRepository _artistRepository;

        /// <summary>
        /// Constructor - wordt aangeroepen wanneer je een TodoArtustApplicationService maakt.
        /// Hier wordt een ArtustRepository instantie aangemaakt en opgeslagen in _postRepository.
        /// </summary>
        public TodoArtistApplicationService()
        {
            _artistRepository = new ArtistRepository();
        }

        /// <summary>
        /// Haalt alle posts op via de repository.
        /// De '=>' syntax betekent een korte methode die direct de repository aanroept.
        /// await zorgt ervoor dat we wachten tot de async operatie klaar is.
        /// </summary>
        public async Task<List<Artist>> GetArtists()
        {
            return await _artistRepository.GetArtists();
        }

        /// <summary>
        /// Haalt een enkele post op aan de hand van een Id.
        /// _postRepository.GetPostById(Id) doet het echte werk, deze service roept dat aan.
        /// await zorgt dat het resultaat wordt teruggegeven zodra het klaar is.
        /// </summary>
         public async Task<List<Concert>> GetConcerts()
        {
            return await _artistRepository.GetConcerts();
        }

        

        /// <summary>
        /// Haalt alle comments op die horen bij een specifieke post (Id).
        /// Wacht op de repository en geeft de lijst met comments terug.
        /// </summary>
        public async Task<List<Concert>> GetConcertForArtist(int ArtistID)
        {
            return await _artistRepository.GetConcertForArtist(ArtistID);
        }
    }
}
