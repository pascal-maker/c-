// Importeer Newtonsoft.Json namespace voor JSON serialisatie attributen
using Newtonsoft.Json;
// Definieer de namespace voor Swagger modellen
namespace Swagger.Models;
// Definieer de Concert klasse om een concert entiteit van de API te representeren
public class Concert
{
    // Property om de concert ID op te slaan met JSON property mapping
    [JsonProperty("id")]
    public int Id { get; set; }

    // Property om de concert naam op te slaan met JSON property mapping
    [JsonProperty("name")]
    public string Name { get; set; }

    // Property om het genre van het concert op te slaan met JSON property mapping
    [JsonProperty("genre")]
    public string Genre { get; set; }

    // Lege regel voor spacing

    // Property om het land van het concert op te slaan met JSON property mapping
    [JsonProperty("country")]
    public string Country { get; set; }

    // Property om de prijs van het concert op te slaan met JSON property mapping
    [JsonProperty("price")]
    public double Price { get; set; }

    // Property om de datum van het concert op te slaan met JSON property mapping
    [JsonProperty("date")]
    public DateTime Date { get; set; }

    // Lege regel voor spacing

    // Override de ToString methode om een aangepaste string representatie te geven
    public override string ToString()
    {
        // Retourneer een geformatteerde string met alle concert details
        return $"Concert ID: {Id}, Name: {Name}, Genre: {Genre}, Country: {Country}, Price: {Price:C}, Date:Date: {Date:yyyy-MM-dd HH:mm}";
    }

}