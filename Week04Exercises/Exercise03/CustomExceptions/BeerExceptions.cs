using System;

namespace beer.Exceptions;

/// <summary>
/// BeerException - Custom exception klasse voor bier-gerelateerde fouten
/// Uitgebreid van de basis Exception klasse om extra informatie te bevatten
/// Wordt gebruikt voor validatie fouten bij het maken van Beer objecten
/// </summary>
public class BeerException: Exception
{
    /// <summary>
    /// Naam van het veld dat de fout veroorzaakte
    /// Bijvoorbeeld: "name", "alcoholpercentage", "brewery"
    /// </summary>
    public string WrongFieldName {get;set;}

    /// <summary>
    /// Waarde van het veld dat de fout veroorzaakte
    /// Bijvoorbeeld: "-1.0", "", "null"
    /// </summary>
    public string WrongValue {get;set;}

    /// <summary>
    /// Constructor voor het maken van een nieuwe BeerException
    /// Initialiseert de exception met een foutmelding en details over het probleem
    /// </summary>
    /// <param name="message">De foutmelding die wordt getoond</param>
    /// <param name="fieldName">Naam van het veld dat de fout veroorzaakte</param>
    /// <param name="fieldValue">Waarde van het veld dat de fout veroorzaakte</param>
    public BeerException(string message, string fieldName, string fieldValue): base(message)
    {
        WrongFieldName = fieldName;
        WrongValue = fieldValue;
    }
}
