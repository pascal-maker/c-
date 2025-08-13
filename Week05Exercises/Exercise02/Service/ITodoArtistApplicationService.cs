using System.Collections.Generic;     // Voor List<T>
using System.Threading.Tasks;         // Voor Task<>
using Ct.Ai.Models;                   // Voor Post en Comment
// using Ct.Ai.Repositories;          // Alleen nodig in de implementatie, niet voor de interface
// using Ct.Ai.Service;               // Niet nodig hier; zie namespace hieronder

namespace Ct.Ai.Service
{
    /// <summary>
    /// Service-laag voor het werken met Posts en hun Comments.
    /// Async (Task/await) zodat IO-werk (HTTP/DB) niet blokkeert.
    /// </summary>
    public interface ITodoArtistApplicationService
    {
        /// <summary>
        /// Haal ALLE artist.
        /// Task<List<artist>> = "er komt later een lijst met artist" (async resultaat).
        /// </summary>
        Task<List<Artist>> GetArtists();

        /// <summary>
        /// Haal ALLE concerts.
        /// Task<List<concers>> = "er komt later een lijst met concerts" (async resultaat).
        /// </summary>
        Task<List<Concert>> GetConcerts();


        /// <summary>
        /// haalt concerten op aan de hand van artist id 
        /// </summary>
        Task<List<Concert>> GetConcertForArtist(int ArtistID);

        
    }
}
