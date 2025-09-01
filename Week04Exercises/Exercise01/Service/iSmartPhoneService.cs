using smartphones.models;

using smartphones.repositories;

namespace smartphones.Services;

/// <summary>
/// ISmartPhoneService Interface - Definieert het contract voor smartphone business logic
/// Service layer interface die de business operaties voor smartphones definieert
/// Scheidt business logic van data toegang (repository pattern)
/// </summary>
public interface ISmartPhoneService
{
    /// <summary>
    /// Haalt alle smartphones op via de service layer
    /// Kan extra business logic bevatten zoals filtering, caching, of validatie
    /// </summary>
    /// <returns>Lijst van alle beschikbare smartphones</returns>
    List<SmartPhone> GetSmartPhones();

    /// <summary>
    /// Voegt een nieuwe smartphone toe via de service layer
    /// Kan extra validatie en business rules bevatten voordat data wordt opgeslagen
    /// </summary>
    /// <param name="smartphone">Het smartphone object om toe te voegen</param>
    void AddSmartPhone(SmartPhone smartphone);
    // We returneren niets, daarom void - alleen toevoegen, geen return waarde nodig

    /// <summary>
    /// Zoekt een smartphone op basis van uniek ID
    /// Service layer kan extra logging of error handling toevoegen
    /// </summary>
    /// <param name="id">Het unieke ID van de smartphone</param>
    /// <returns>SmartPhone object of null als niet gevonden</returns>
    SmartPhone? GetSmartPhoneById(int id);

    /// <summary>
    /// Zoekt een smartphone op basis van merk (Apple, Samsung, etc.)
    /// Kan business logic bevatten zoals case-insensitive zoeken
    /// </summary>
    /// <param name="brand">Het merk om te zoeken</param>
    /// <returns>SmartPhone object of null als niet gevonden</returns>
    SmartPhone? GetSmartPhoneByBrand(string brand);

    /// <summary>
    /// Zoekt een smartphone op basis van type (iPhone 14, Galaxy S23, etc.)
    /// Service layer kan fuzzy matching of suggesties toevoegen
    /// </summary>
    /// <param name="type">Het type om te zoeken</param>
    /// <returns>SmartPhone object of null als niet gevonden</returns>
    SmartPhone? GetSmartPhoneByType(string type);
}

