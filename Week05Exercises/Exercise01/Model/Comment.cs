using Newtonsoft.Json;

namespace Ct.Ai.Models;

/// <summary>
/// Comment - Model klasse voor het representeren van een comment object
/// Gebruikt JSON attributes voor mapping tussen C# properties en JSON velden
/// Volgt het Data Transfer Object (DTO) pattern voor API communicatie
/// </summary>
public class Comment
{
    /// <summary>
    /// ID van de post waar deze comment bij hoort
    /// JSON mapping: "postId" in JSON wordt gemapt naar PostId property
    /// </summary>
    [JsonProperty("postId")]
    public int PostId { get; set; }

    /// <summary>
    /// Uniek ID van de comment
    /// JSON mapping: "id" in JSON wordt gemapt naar Id property
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Naam van de auteur van de comment
    /// JSON mapping: "name" in JSON wordt gemapt naar Name property
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Email adres van de auteur van de comment
    /// JSON mapping: "email" in JSON wordt gemapt naar Email property
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Inhoud van de comment (de tekst)
    /// JSON mapping: "body" in JSON wordt gemapt naar Body property
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }

    /// <summary>
    /// Override van ToString() voor een leesbare string representatie
    /// Toont ID, post ID en de inhoud van de comment
    /// </summary>
    /// <returns>Geformatteerde string met comment informatie</returns>
    public override string ToString()
    {
        // String interpolatie voor nette weergave van comment gegevens
        return $"Id: {Id}, On Post: {PostId}: {Body}";
    }
}