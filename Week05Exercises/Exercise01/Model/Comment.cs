// Import the Newtonsoft.Json namespace for JSON serialization attributes
using Newtonsoft.Json;
// Define the namespace for custom models
namespace Ct.Ai.Models;
// Define the Comment class to represent a comment on a post from the API
public class Comment
{
    // Property to store the post ID that this comment belongs to with JSON property mapping
    [JsonProperty("postId")]
    public int PostId { get; set; }

    // Property to store the comment ID with JSON property mapping
    [JsonProperty("id")]
    public int Id { get; set; }

    // Property to store the commenter's name with JSON property mapping
    [JsonProperty("name")]
    public string Name { get; set; }

    // Property to store the commenter's email with JSON property mapping
    [JsonProperty("email")]
    public string email { get; set; }

    // Property to store the comment body content with JSON property mapping
    [JsonProperty("Body")]
    public string Body { get; set; }

    // Override the ToString method to provide a custom string representation
    public override string ToString()
    {
        // Return a formatted string with comment ID, post ID, and body
        return $" Comment Id: {Id}, on Post {PostId}: {Body}";
    }

}