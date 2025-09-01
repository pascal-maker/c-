using System;
using beer.Exceptions;

namespace beer.Models;

/// <summary>
/// Beer - Model klasse voor het representeren van een bier object
/// Bevat alle eigenschappen die een bier beschrijven en validatie logica
/// </summary>
public class Beer
{
    /// <summary>
    /// Naam van het bier (bijv. "Jupiler", "Heineken")
    /// </summary>
    public string Name {get;set;}

    /// <summary>
    /// Brouwerij die het bier produceert (bijv. "AB InBev", "Heineken")
    /// </summary>
    public string Brewery {get;set;}

    /// <summary>
    /// Alcohol percentage van het bier (bijv. 5.0, 8.5)
    /// Gebruikt double voor eenvoud en omdat alcohol percentages geen financiële precisie nodig hebben
    /// </summary>
    public double AlcoholPercentage {get;set;}

    /// <summary>
    /// Kleur van het bier (bijv. "blond", "bruin", "zwart")
    /// </summary>
    public string Color {get;set;}

    /// <summary>
    /// Constructor voor het maken van een nieuw Beer object
    /// Voert validatie uit op alle parameters voordat het object wordt aangemaakt
    /// </summary>
    /// <param name="name">Naam van het bier</param>
    /// <param name="brewery">Brouwerij naam</param>
    /// <param name="alcoholpercentage">Alcohol percentage (moet >= 0 zijn)</param>
    /// <param name="color">Kleur van het bier</param>
    /// <exception cref="BeerException">Wordt gegooid als validatie faalt</exception>
    public Beer(string name,string brewery,double alcoholpercentage,string color)
    {
        // Validatie: naam mag niet leeg zijn
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new BeerException("name cannot be empty.",nameof(name),name ?? string.Empty);
        }

        // Validatie: brouwerij mag niet leeg zijn
        if(string.IsNullOrWhiteSpace(brewery))
        {
            throw new BeerException("brewery cannot be empty.",nameof(brewery),brewery?? string.Empty);
        }

        // Validatie: alcohol percentage mag niet negatief zijn
        if (alcoholpercentage < 0)
        {
          throw new BeerException("alcohol cannot be negative.",nameof(alcoholpercentage),alcoholpercentage.ToString());
        }

        // Validatie: kleur mag niet leeg zijn
        if(string.IsNullOrWhiteSpace(color))
        {
            throw new BeerException("color cannot be empty.",nameof(color),color?? string.Empty);
        }

        // Als alle validaties slagen, wijs de waarden toe aan de properties
        Name = name;
        Brewery = brewery;
        AlcoholPercentage = alcoholpercentage;
        Color = color;
    }

    /// <summary>
    /// Override van ToString() om een leesbare string representatie van het Beer object te geven
    /// Wordt gebruikt voor console output en debugging
    /// </summary>
    /// <returns>String met alle bier eigenschappen</returns>
    public override string ToString()
    {
        return $"Name:{Name}, Brewery:{Brewery},AlcoholPercentage:{AlcoholPercentage},Color:{Color}";
    }
}
