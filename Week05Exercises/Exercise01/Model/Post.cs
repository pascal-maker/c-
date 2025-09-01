// Import the Newtonsoft.Json namespace for JSON serialization attributes
using Newtonsoft.Json;

// Define the namespace for custom models
namespace Ct.Ai.Models;

/// <summary>
/// Post - Model klasse voor het representeren van een blog post object
/// Gebruikt JSON attributes voor mapping tussen C# properties en JSON velden
/// Volgt het Data Transfer Object (DTO) pattern voor API communicatie
/// </summary>
public class Post
{
    /// <summary>
    /// ID van de gebruiker die de post heeft geschreven
    /// JSON mapping: "userId" in JSON wordt gemapt naar UserId property
    /// </summary>
    [JsonProperty("userId")]
    public int UserId { get; set; }

    /// <summary>
    /// Uniek ID van de post
    /// JSON mapping: "id" in JSON wordt gemapt naar Id property
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Titel van de post
    /// JSON mapping: "title" in JSON wordt gemapt naar Title property
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }

    /// <summary>
    /// Inhoud van de post (de hoofdtekst)
    /// JSON mapping: "body" in JSON wordt gemapt naar Body property
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }

    /// <summary>
    /// Override van ToString() voor een leesbare string representatie
    /// Toont ID en titel van de post
    /// </summary>
    /// <returns>Geformatteerde string met post informatie</returns>
    public override string ToString()
    {
        // String interpolatie voor nette weergave van post gegevens
        return $"Id: {Id}, Title: {Title}";
    }
}