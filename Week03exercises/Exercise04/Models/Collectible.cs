// Abstracte klasse die de basis vormt voor alle verzamelobjecten
// Implementeert IComparable zodat objecten gesorteerd kunnen worden
public abstract class Collectible : IComparable
{
    // Eigenschap voor de naam van het object
    public string Name { get; set; }

    // Eigenschap voor het jaar van oorsprong
    public int YearOfOrigin { get; set; }

    // Eigenschap voor de prijs van het object
    public double Price { get; set; }

    // Constructor die naam, jaar en prijs instelt
    public Collectible(string name, int yearoforigin, double price)
    {
        Name = name;                 // Zet de naam
        YearOfOrigin = yearoforigin; // Zet het jaar van oorsprong
        Price = price;               // Zet de prijs
    }

    // Read-only eigenschap die de startbiedprijs berekent als 80% van de prijs
    public double StartBidPrice
    {
        get { return Price * 0.80; } // Berekening startbod
    }

    // Abstracte eigenschap die het type van de collectie retourneert (wordt in subklassen ingevuld)
    public abstract string CollectType { get; }

    // Implementatie van CompareTo om op naam te sorteren
    public int CompareTo(object obj)
    {
        // Controleer of het object ook een Collectible is
        if (obj is Collectible other)
        {
            // Vergelijk op naam (alfabetisch)
            return this.Name.CompareTo(other.Name);
        }

        // Foutmelding als het geen Collectible is
        throw new ArgumentException("Object is not a name");
    }

    // Virtuele ToString-methode die een stringrepresentatie teruggeeft
    public virtual string ToString()
    {
        return $"Name {Name}, Year {YearOfOrigin}, Price: {Price}";
    }
}
