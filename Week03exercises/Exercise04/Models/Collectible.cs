public abstract class Collectible : IComparable
{
    public string Name {get;set;}

    public int YearOfOrigin {get;set;}

    public double Price {get;set;}



    public Collectible(string name,int yearoforigin,double price)
    {
        Name = name;
        YearOfOrigin = yearoforigin;
        Price = price;
    }

    public double StartBidPrice
    {
        get {return Price * 0.80;}
    }

    // Abstract property - MOET geïmplementeerd worden in subklassen (Coin, Stamp, etc.)
    // Elke verzamelobject heeft een type (bijv. "Coin", "Stamp", "Card")
    public abstract string CollectType {get;}

    // CompareTo methode voor sortering van Collectible objecten
    // Vergelijkt objecten op basis van hun naam (alfabetisch)
    public int CompareTo(object obj)
    {
        // Controleer of het object een Collectible is
        if(obj is Collectible other)
        {
            // Vergelijk namen alfabetisch
            // Return: -1 (kleiner), 0 (gelijk), +1 (groter)
            return this.Name.CompareTo(other.Name);
        }

        // Gooi exception als object geen Collectible is
        throw new ArgumentException("Object is not a name");
    }

    // Virtual ToString methode - kan overschreven worden in subklassen
    // Maakt een mooie string representatie van het Collectible object
    public virtual string ToString()
    {
        // String interpolatie voor nette weergave
        return $"Name {Name},Year{YearOfOrigin},Price:{Price}";
    }



}