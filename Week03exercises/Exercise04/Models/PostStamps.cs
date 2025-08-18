// Klasse die een postzegel (post stamp) voorstelt
// Erft van de abstracte klasse Collectible
public class PostStamps : Collectible
{
    // Eigenschap voor de afbeelding (bijvoorbeeld welke tekening of figuur op de postzegel staat)
    public string Image { get; set; }

    // Constructor voor PostStamps
    // Parameters:
    // name          - Naam van de postzegel
    // yearoforigin  - Jaar waarin de postzegel is uitgegeven
    // price         - Prijs van de postzegel
    // image         - Afbeelding op de postzegel
    // Roept de constructor van de Collectible-basis aan voor naam, jaar en prijs
    public PostStamps(string name, int yearoforigin, double price, string image) 
        : base(name, yearoforigin, price)
    {
        Image = image; // Sla de afbeelding op
    }

    // Overschrijving van ToString()
    // Geeft alleen de naam van de postzegel terug
    public override string ToString()
    {
        return $" Name:{Name}";
    }

    // Implementatie van de abstracte eigenschap CollectType
    // Geeft altijd "post stamps" terug als type
    public override string CollectType => "post stamps";
}
