// Importeer System.Net.Http voor HTTP client functionaliteit
using System.Net.Http;                     // Nodig voor HttpClient
// Importeer System.Text voor string encoding
using System.Text;                          // Nodig voor Encoding
// Importeer System.Text.Json.Serialization voor JSON serialisatie
using System.Text.Json.Serialization;
// Importeer System.Threading.Tasks voor async/await functionaliteit
using System.Threading.Tasks;               // Nodig voor Task<>
// Importeer Microsoft.VisualBasic voor Visual Basic functionaliteit
using Microsoft.VisualBasic;
// Importeer Newtonsoft.Json voor JSON serialisatie/deserialisatie
using Newtonsoft.Json; 
// Importeer System.Linq voor LINQ operaties
using System.Linq;                           // Nodig voor JSON (JsonConvert)
// Importeer custom models voor Artist en Concert klassen
using Swagger.Models;                          // Voor Post en Comment klassen
// Importeer custom repositories namespace
using Swagger.Repositories;

// Definieer de namespace voor repository implementaties
namespace Swagger.Repositories
{
    // Definieer de ArtistRepository klasse die IArtistRepository interface implementeert
    public class ArtistRepository : IArtistRepository
    {
        // Private readonly veld om de HTTP client instantie op te slaan
        private readonly HttpClient _httpClient;

        // Constructor om de repository te initialiseren met een nieuwe HTTP client
        public ArtistRepository()
        {
            // Maak een nieuwe HTTP client instantie voor het maken van API calls
            _httpClient = new HttpClient();
        }

        // Implementatie van GetAllArtists methode om alle artiesten van de API op te halen
        public async Task<List<Artist>> GetAllArtists()
        {
            // Maak een HTTP GET request naar de artiesten endpoint en krijg de response als string
            var response = await _httpClient.GetStringAsync($"{URL.BASE_URL}/artists");
            // Deserialiseer de JSON response naar een List<Artist> en retourneer deze
            return JsonConvert.DeserializeObject<List<Artist>>(response)!;
        }

        // Implementatie van GetAllConcerts methode om alle concerten van de API op te halen
        public async Task<List<Concert>> GetAllConcerts()
        {
            // Maak een HTTP GET request naar de concerten endpoint en krijg de response als string
            var response = await _httpClient.GetStringAsync($"{URL.BASE_URL}/concerts");
            // Deserialiseer de JSON response naar een List<Concert> en retourneer deze
            return JsonConvert.DeserializeObject<List<Concert>>(response)!;
        }

        // Lege regel voor spacing

        // Lege regel voor spacing

        // Lege regel voor spacing

        // Lege regel voor spacing

        // Implementatie van GetConcertForArtist methode om concerten voor een specifieke artiest op te halen
        public async Task<List<Concert>> GetConcertForArtist(int artistId)
        {
            // Haal alle artiesten op van de API
            var artistsJson = await _httpClient.GetStringAsync($"{URL.BASE_URL}/artists");
            // Deserialiseer de JSON response naar een List<Artist>
            var artists = JsonConvert.DeserializeObject<List<Artist>>(artistsJson)!;
            // Zoek de specifieke artiest op ID
            var artist = artists.FirstOrDefault(a => a.Id == artistId);
            // Controleer of de artiest bestaat en concert IDs heeft
            if (artist == null || artist.ConcertIds == null || artist.ConcertIds.Count == 0)
            {
                // Retourneer een lege lijst als er geen artiest of concert IDs zijn
                return new List<Concert>();
            }

            // Haal alle concerten op van de API
            var concertsJson = await _httpClient.GetStringAsync($"{URL.BASE_URL}/concerts");
            // Deserialiseer de JSON response naar een List<Concert>
            var concerts = JsonConvert.DeserializeObject<List<Concert>>(concertsJson)!;
            // Filter de concerten op basis van de artiest concert IDs en retourneer deze
            return concerts.Where(c => artist.ConcertIds.Contains(c.Id)).ToList();

            // Lege regel voor spacing

            // Lege regel voor spacing

        }

        // Lege regel voor spacing

    }
}