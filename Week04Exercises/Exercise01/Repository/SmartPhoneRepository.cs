using System.Runtime.CompilerServices;
using smartphones.models;

namespace smartphones.repositories;

/// <summary>
/// SmartPhoneRepository - Implementeert ISmartPhoneRepository interface
/// Verantwoordelijk voor data toegang tot smartphone gegevens via CSV bestand
/// Volgt het Repository Pattern voor scheiding van data toegang en business logic
/// </summary>
public class SmartPhoneRepository : ISmartPhoneRepository
{
    // Constant voor het pad naar het CSV bestand
    // Private omdat alleen deze klasse het bestandspad moet kennen
    private const string csvFile = "data/smartphones.csv";

    /// <summary>
    /// Haalt alle smartphones op uit het CSV bestand
    /// Leest het bestand regel voor regel en converteert naar SmartPhone objecten
    /// </summary>
    /// <returns>Lijst van alle smartphones uit het CSV bestand</returns>
    public List<SmartPhone> GetSmartPhones()
    {
        // Maak een lege lijst voor de smartphones
        List<SmartPhone> smartphones = new List<SmartPhone>();

        // Lees alle regels uit het CSV bestand
        string[] lines = File.ReadAllLines(csvFile);

        // Loop door alle regels (start bij 1 om header over te slaan)
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            // Split elke regel op komma's om de verschillende waarden te krijgen
            string[] entries = line.Split(',');

            // Controleer of er genoeg kolommen zijn (minimaal 6)
            if (entries.Length >= 6)
            {
                // Maak een nieuw SmartPhone object met object initializer syntax
                SmartPhone newSmartPhone = new SmartPhone
                {
                    Id = int.Parse(entries[0].Trim()),           // Converteer string naar int
                    Brand = entries[1].Trim(),                   // Merk (Apple, Samsung, etc.)
                    Type = entries[2].Trim(),                    // Type (iPhone 14, Galaxy S23, etc.)
                    ReleaseYear = int.Parse(entries[3].Trim()),  // Uitgave jaar
                    StartPrice = int.Parse(entries[4].Trim()),   // Startprijs
                    OperatingSystem = entries[5].Trim()          // Besturingssysteem (iOS, Android)
                };

                // Voeg de smartphone toe aan de lijst
                smartphones.Add(newSmartPhone);
            }
        }

        return smartphones;
    }

    /// <summary>
    /// Voegt een nieuwe smartphone toe aan het CSV bestand
    /// Haalt eerst alle bestaande data op, voegt nieuwe toe, en schrijft alles terug
    /// </summary>
    /// <param name="smartphone">Het nieuwe smartphone object om toe te voegen</param>
    public void AddSmartPhone(SmartPhone smartphone)
    {
        // Defensive programming: controleer of smartphone niet null is
        ArgumentNullException.ThrowIfNull(smartphone);

        // Haal alle bestaande smartphones op
        var smartphones = GetSmartPhones();

        // Voeg de nieuwe smartphone toe aan de lijst
        smartphones.Add(smartphone);

        // Maak een nieuwe lijst voor CSV regels met collection initialization
        var lines = new List<string>
        {
            "Id,brand,type,releaseyear,startprice,operatingsystem"  // CSV header
        };

        // Converteer elke smartphone naar een CSV regel
        foreach (var phone in smartphones)
        {
            // String interpolatie voor nette CSV formatting
            lines.Add($"{phone.Id},{phone.Brand},{phone.Type},{phone.ReleaseYear},{phone.StartPrice},{phone.OperatingSystem}");
        }

        // Schrijf alle regels naar het CSV bestand (overschrijft het hele bestand)
        File.WriteAllLines(csvFile, lines);
    }

    /// <summary>
    /// Zoekt een smartphone op basis van ID (uniek nummer)
    /// Gebruikt FirstOrDefault om null terug te geven als niets gevonden
    /// </summary>
    /// <param name="id">Het ID van de smartphone om te zoeken</param>
    /// <returns>SmartPhone object of null als niet gevonden</returns>
    public SmartPhone? GetSmartPhoneById(int id)
    {
        var smartphones = GetSmartPhones();

        // Lambda expressie: voor elke smartphone s, check of s.Id == id
        // FirstOrDefault: geeft eerste match of null als niets gevonden
        return smartphones.FirstOrDefault(s => s.Id == id);
    }

    /// <summary>
    /// Zoekt een smartphone op basis van merk (Apple, Samsung, etc.)
    /// Geeft de eerste smartphone van dat merk terug
    /// </summary>
    /// <param name="brand">Het merk om te zoeken</param>
    /// <returns>SmartPhone object of null als niet gevonden</returns>
    public SmartPhone? GetSmartPhoneByBrand(string brand)
    {
        var smartphones = GetSmartPhones();

        // Lambda expressie: voor elke smartphone s, check of s.Brand == brand
        return smartphones.FirstOrDefault(s => s.Brand == brand);
    }

    /// <summary>
    /// Zoekt een smartphone op basis van type (iPhone 14, Galaxy S23, etc.)
    /// Geeft de eerste smartphone van dat type terug
    /// </summary>
    /// <param name="type">Het type om te zoeken</param>
    /// <returns>SmartPhone object of null als niet gevonden</returns>
    public SmartPhone? GetSmartPhoneByType(string type)
    {
        var smartphones = GetSmartPhones();

        // Lambda expressie: voor elke smartphone s, check of s.Type == type
        return smartphones.FirstOrDefault(s => s.Type == type);
    }
}

