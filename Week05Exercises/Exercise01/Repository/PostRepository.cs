using System.Net.Http;

using System.Text;

using System.Threading.Tasks;

using Newtonsoft.Json;

using Ct.Ai.Models;

using Ct.Ai.Repositories;

namespace Ct.Ai.Repositories
{
    /// <summary>
    /// PostRepository - Concrete implementatie van IPostRepository
    /// Verantwoordelijk voor HTTP communicatie met externe JSON API
    /// Gebruikt HttpClient voor REST API calls en JSON serialization
    /// </summary>
    public class PostRepository: IPostRepository
    {
        // HttpClient voor het maken van HTTP requests naar externe API
        // Readonly omdat deze niet veranderd hoeft te worden na initialisatie
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor - Initialiseert een nieuwe HttpClient voor API communicatie
        /// HttpClient is thread-safe en kan hergebruikt worden voor meerdere requests
        /// </summary>
        public PostRepository()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Haalt alle posts op uit de externe API via HTTP GET
        /// Async methode voor niet-blokkerende I/O operaties
        /// </summary>
        /// <returns>Lijst van alle beschikbare posts</returns>
        public async Task<List<Post>> GetPosts()
        {
            // HTTP GET request naar /posts endpoint
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts");
            // JSON deserialization: converteer JSON string naar List<Post> objecten
            return JsonConvert.DeserializeObject<List<Post>>(response);
        }

        /// <summary>
        /// Haalt een specifieke post op basis van ID op via HTTP GET
        /// Async methode voor het ophalen van individuele posts
        /// </summary>
        /// <param name="Id">Het unieke ID van de post</param>
        /// <returns>De gevonden post of null als niet gevonden</returns>
        public async Task<Post> GetPostById(int Id)
        {
            // HTTP GET request naar /posts/{id} endpoint
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts/{Id}");
            // JSON deserialization: converteer JSON string naar Post object
            return JsonConvert.DeserializeObject<Post>(response);
        }

        /// <summary>
        /// Voegt een nieuwe post toe aan de externe API via HTTP POST
        /// Async methode voor het versturen van data naar server
        /// </summary>
        /// <param name="post">Het post object om toe te voegen</param>
        /// <returns>De toegevoegde post met server-generated ID</returns>
        public async Task<Post> AddPost(Post post)
        {  
            // JSON serialization: converteer Post object naar JSON string
            var jsonContent = JsonConvert.SerializeObject(post);
            // Maak HTTP content met JSON data en UTF-8 encoding
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // HTTP POST request naar /posts endpoint met JSON data
            var response = await _httpClient.PostAsync($"{Global.BASE_URL}/posts", content);
            // Lees response content als string
            var responseContent = await response.Content.ReadAsStringAsync();
            // JSON deserialization: converteer response naar Post object
            return JsonConvert.DeserializeObject<Post>(responseContent)!;
        }

        /// <summary>
        /// Haalt alle comments op voor een specifieke post via HTTP GET
        /// Async methode voor het ophalen van gerelateerde data
        /// </summary>
        /// <param name="Id">Het ID van de post waarvan comments opgehaald moeten worden</param>
        /// <returns>Lijst van comments voor de opgegeven post</returns>
        public async Task<List<Comment>> GetCommentsForPost(int Id)
        {
            // HTTP GET request naar /posts/{id}/comments endpoint
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts/{Id}/comments");
            // JSON deserialization: converteer JSON string naar List<Comment> objecten
            return JsonConvert.DeserializeObject<List<Comment>>(response);
        }
    }
}

