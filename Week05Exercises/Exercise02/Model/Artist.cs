// Importeer Newtonsoft.Json namespace voor JSON serialisatie attributen
using Newtonsoft.Json;
// Definieer de namespace voor Swagger modellen
namespace Swagger.Models;
// Definieer de Artist klasse om een artiest entiteit van de API te representeren
public class Artist
{
    // Property om de artiest ID op te slaan met JSON property mapping
    [JsonProperty("id")]
    public int Id { get; set; }

    // Property om de artiest naam op te slaan met JSON property mapping
    [JsonProperty("name")]
    public string Name { get; set; }

    // Property om het genre van de artiest op te slaan met JSON property mapping
    [JsonProperty("genre")]
    public string Genre { get; set; }

    // Property om de email van de artiest op te slaan met JSON property mapping
    [JsonProperty("email")]
    public string Email { get; set; }

    // Property om het land van de artiest op te slaan met JSON property mapping
    [JsonProperty("country")]
    public string Country { get; set; }

    // Property om de lijst van concert IDs op te slaan met JSON property mapping
    [JsonProperty("concertIds")]
    public List<int> ConcertIds { get; set; }

    // Override de ToString methode om een aangepaste string representatie te geven
    public override string ToString()
    {
        // Format de concert IDs als een leesbare string
        var concertIdsText = string.Join(",", ConcertIds);
        // Retourneer een geformatteerde string met alle artiest details
        return $"Artist ID: {Id}, Name: {Name}, Genre: {Genre}, Email: {Email}, Country: {Country}, Concert IDs: [{concertIdsText}]";
    }

}