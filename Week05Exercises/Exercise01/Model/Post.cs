// Import the Newtonsoft.Json namespace for JSON serialization attributes
using Newtonsoft.Json;
// Define the namespace for custom models
namespace Ct.Ai.Models;
// Define the Post class to represent a blog post from the API
public class Post
{
    // Property to store the user ID with JSON property mapping
    [JsonProperty("userId")]
    public int UserId { get; set; }

    // Property to store the post ID with JSON property mapping
    [JsonProperty("id")]
    public int Id { get; set; }

    // Property to store the post title with JSON property mapping
    [JsonProperty("title")]
    public string Title { get; set; }

    // Property to store the post body content with JSON property mapping
    [JsonProperty("body")]
    public string Body { get; set; }

    // Override the ToString method to provide a custom string representation
    public override string ToString()
    {
        // Return a formatted string with post ID and title
        return $"Id: {Id}, Title: {Title}";
    }

}