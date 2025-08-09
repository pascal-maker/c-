using Newtonsoft.Json;
namespace Ct.Ai.Models;

public class Artist
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("genre")]
    public string Genre { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("concertIds")]
    public List<int> ConcertIds { get; set; } = new();

    public override string ToString()
    {
        var concertIdsText = string.Join(", ", ConcertIds);
        return $"Artist {Id} | Name: {Name}, Genre: {Genre}, Country: {Country}, ConcertIds: [{concertIdsText}]";
    }
}