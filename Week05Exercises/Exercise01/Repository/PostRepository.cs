// Import System.Net.Http for HTTP client functionality
using System.Net.Http;                     // Nodig voor HttpClient
// Import System.Text for string encoding
using System.Text;                          // Nodig voor Encoding
// Import System.Threading.Tasks for async/await functionality
using System.Threading.Tasks;               // Nodig voor Task<>
// Import Newtonsoft.Json for JSON serialization/deserialization
using Newtonsoft.Json;                      // Nodig voor JSON (JsonConvert)
// Import custom models for Post and Comment classes
using Ct.Ai.Models;                          // Voor Post en Comment klassen
// Import custom repositories namespace
using Ct.Ai.Repositories; 

// Define the namespace for repository implementations
namespace Ct.Ai.Repositories
{
    // Define the PostRepository class that implements IPostRepository interface
    public class PostRepository : IPostRepository
    {
        // Private readonly field to store the HTTP client instance
        private readonly HttpClient _httpClient;

        // Constructor to initialize the repository with a new HTTP client
        public PostRepository()
        {
            // Create a new HTTP client instance for making API calls
            _httpClient = new HttpClient();
        }

        // Implementation of GetPosts method to retrieve all posts from the API
        public async Task<List<Post>> GetPosts()
        {
            // Make an HTTP GET request to the posts endpoint and get the response as string
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts");
            // Deserialize the JSON response into a List<Post> and return it
            return JsonConvert.DeserializeObject<List<Post>>(response)!;
        }

        // Implementation of GetPostById method to retrieve a specific post by ID
        public async Task<Post> GetPostById(int Id)
        {
            // Make an HTTP GET request to the specific post endpoint and get the response as string
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts/{Id}");
            // Deserialize the JSON response into a Post object and return it
            return JsonConvert.DeserializeObject<Post>(response)!;
        }

        // Implementation of AddPost method to create a new post via the API
        public async Task<Post> AddPost(Post post)
        {
            // Serialize the post object to JSON string
            var jsonContent = JsonConvert.SerializeObject(post);

            // Create HTTP content with the JSON string, UTF-8 encoding, and JSON media type
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Make an HTTP POST request to the posts endpoint with the JSON content
            var response = await _httpClient.PostAsync($"{Global.BASE_URL}/posts", content);

            // Read the response content as string and deserialize it to a Post object
            return JsonConvert.DeserializeObject<Post>(await response.Content.ReadAsStringAsync())!;

            // Empty line for spacing

        }

        // Implementation of GetCommentsForPost method to retrieve comments for a specific post
        public async Task<List<Comment>> GetCommentsForPost(int Id)
        {
            // Make an HTTP GET request to the comments endpoint for a specific post and get the response as string
            var response = await _httpClient.GetStringAsync($"{Global.BASE_URL}/posts/{Id}/comments");
            // Deserialize the JSON response into a List<Comment> and return it
            return JsonConvert.DeserializeObject<List<Comment>>(response)!;
        }

        // Empty line for spacing

    }
    
    // Empty line for spacing

}