using Newtonsoft.Json;
namespace Ct.Ai.Models;

public class Concert
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("genre")]
    public string Genre { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("price")]
    public double Price { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"Concert {Id} | Name: {Name}, Genre: {Genre}, Country: {Country}, Price: {Price}, Date: {Date:yyyy-MM-dd HH:mm}";
    }
}