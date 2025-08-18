// Klasse die een wijn (wine) voorstelt
// Erft van de abstracte klasse Collectible
public class Wine : Collectible
{
    // Enum die de mogelijke types wijn definieert
    public enum WineType { RED, WHITE, ROSE, SPARKLING }

    // Eigenschap voor de prijs per glas
    public double PricePerGlass { get; set; }

    // Eigenschap voor het land van herkomst
    public string Country { get; set; }

    // Eigenschap voor het type wijn (uit de enum hierboven)
    public WineType Type { get; set; }

    // Constructor voor Wine
    // Parameters:
    // name          - Naam van de wijn
    // yearoforigin  - Jaar waarin de wijn is gemaakt
    // price         - Prijs van de wijn
    // type          - Type wijn (bijvoorbeeld RED, WHITE, ...)
    // priceperglass - Prijs per glas
    // country       - Land van herkomst
    // Roept de constructor van Collectible aan voor naam, jaar en prijs
    public Wine(string name, int yearoforigin, double price, WineType type, double priceperglass, string country) 
        : base(name, yearoforigin, price)
    {
        Type = type;                 // Zet het type wijn
        PricePerGlass = priceperglass; // Zet de prijs per glas
        Country = country;             // Zet het land van herkomst
    }

    // Overschrijving van ToString()
    // Geeft naam en land terug als string
    public override string ToString()
    {
        return $" Name:{Name},Country: {Country}";
    }

    // Implementatie van de abstracte eigenschap CollectType
    // Geeft altijd "wine" terug als verzameltype
    public override string CollectType => "wine";
}
