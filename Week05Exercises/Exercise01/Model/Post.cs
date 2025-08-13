using Newtonsoft.Json;

namespace Ct.Ai.Models;

public class Post
{
    [JsonProperty("userId")]
    public int UserId { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}";
    }
}