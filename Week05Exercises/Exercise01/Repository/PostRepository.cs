using System.Net.Http;                     // Nodig voor HttpClient
using System.Text;                          // Nodig voor Encoding
using System.Threading.Tasks;               // Nodig voor Task<>
using Newtonsoft.Json;                      // Nodig voor JSON (JsonConvert)
using Ct.Ai.Models;                          // Voor Post en Comment klassen
using Ct.Ai.Repositories;                    // Voor IPostRepository interface

namespace Ct.Ai.Repositories
{
    // Deze class implementeert IPostRepository en zorgt voor het ophalen/toevoegen van posts via HTTP requests
    public class PostRepository : IPostRepository
    {
        // HttpClient wordt gebruikt om verbinding te maken met externe API's
        private readonly HttpClient _httpClient;

        // Constructor: maakt een nieuwe HttpClient aan
        public PostRepository()
        {
            _httpClient = new HttpClient();
        }

        // Haalt ALLE posts op van de API
        public async Task<List<Post>> GetPosts()
        {
            // Verstuur een GET-verzoek naar /posts en wacht op het antwoord (JSON string)
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts");

            // Zet de JSON string om in een lijst van Post objecten
            return JsonConvert.DeserializeObject<List<Post>>(response)!;
        }

        // Haalt één specifieke post op aan de hand van het ID
        public async Task<Post> GetPostById(int Id)
        {
            // Verstuur GET naar /posts/{Id}
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts/{Id}");

            // Zet JSON string om naar een Post object
            return JsonConvert.DeserializeObject<Post>(response)!;
        }

        // Voegt een nieuwe post toe via POST request
        public async Task<Post> AddPost(Post post)
        {
            // Zet het Post object om naar een JSON string
            var jsonContent = JsonConvert.SerializeObject(post);

            // Maak een StringContent zodat we JSON kunnen versturen
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Verstuur POST naar /posts met de JSON content
            var response = await _httpClient.PostAsync($"{Global.BASE_URL}/posts", content);

            // Lees de response body (JSON) en zet om naar een Post object
            return JsonConvert.DeserializeObject<Post>(await response.Content.ReadAsStringAsync())!;
        }

        // Haalt alle comments op die bij een specifieke post horen
        public async Task<List<Comment>> GetCommentsForPost(int Id)
        {
            // Verstuur GET naar /posts/{Id}/comments
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts/{Id}/comments");

            // Zet JSON string om naar een lijst van Comment objecten
            return JsonConvert.DeserializeObject<List<Comment>>(response)!;
        }
    }
}
