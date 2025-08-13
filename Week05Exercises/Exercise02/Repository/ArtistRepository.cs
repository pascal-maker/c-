using System.Net.Http;                     // Nodig voor HttpClient
using System.Text;                          // Nodig voor Encoding
using System.Threading.Tasks;               // Nodig voor Task<>
using System.Linq;                          // Nodig voor LINQ (FirstOrDefault, Where)
using Newtonsoft.Json;                      // Nodig voor JSON (JsonConvert)
using Ct.Ai.Models;                          // Voor Post en Comment klassen
using Ct.Ai.Repositories;                    // Voor IPostRepository interface

namespace Ct.Ai.Repositories
{
    // Deze class implementeert IArtistRepository en zorgt voor het ophalen/toevoegen van posts via HTTP requests
    public class ArtistRepository : IArtistRepository
    {
        // HttpClient wordt gebruikt om verbinding te maken met externe API's
        private readonly HttpClient _httpClient;

        // Constructor: maakt een nieuwe HttpClient aan
        public ArtistRepository()
        {
            _httpClient = new HttpClient();
        }

        // Haalt ALLE artists op van de API
        public async Task<List<Artist>> GetArtists()
        {
            // Verstuur een GET-verzoek naar /artists en wacht op het antwoord (JSON string)
            var response = await _httpClient.GetStringAsync($"{URL.BASE_URL}/artists");

            // Zet de JSON string om in een lijst van Artist objecten
            return JsonConvert.DeserializeObject<List<Artist>>(response)!;
        }


         // Haalt ALLE conncerts op van de API
        public async Task<List<Concert>> GetConcerts()
        {
            // Verstuur een GET-verzoek naar /concerts en wacht op het antwoord (JSON string)
            var response = await _httpClient.GetStringAsync($"{URL.BASE_URL}/concerts");

            // Zet de JSON string om in een lijst van Artist objecten
            return JsonConvert.DeserializeObject<List<Concert>>(response)!;
        }

        


        // Haalt alle concerts op die bij een specifieke artist horen
        public async Task<List<Concert>> GetConcertForArtist(int artistId)
        {
            // 1) Haal alle artists op en vind de gevraagde artist
            var artistsJson = await _httpClient.GetStringAsync($"{URL.BASE_URL}/artists");
            var artists = JsonConvert.DeserializeObject<List<Artist>>(artistsJson)!;
            var artist = artists.FirstOrDefault(a => a.Id == artistId);
            if (artist == null || artist.ConcertIds == null || artist.ConcertIds.Count == 0)
            {
                return new List<Concert>();
            }

            // 2) Haal alle concerten op en filter op de concertIds van de artist
            var concertsJson = await _httpClient.GetStringAsync($"{URL.BASE_URL}/concerts");
            var concerts = JsonConvert.DeserializeObject<List<Concert>>(concertsJson)!;
            return concerts.Where(c => artist.ConcertIds.Contains(c.Id)).ToList();
        }
    }
}
