using Newtonsoft.Json;
namespace Ct.Ai.Models;

public class Comment
{
    [JsonProperty("postID")]
    public int PostId { get; set; }


    [JsonProperty("id")]
    public int ID { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }


    [JsonProperty("email")]
    public string email { get; set; }


    [JsonProperty("Body")]
    public string Body { get; set; }


    public override string ToString()
    {
        return $" Comment {ID} on Post {PostId}: {Body}";
    }


    





}