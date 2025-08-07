namespace Ct.Ai.Models

{
    // Enumeration for Wine Types
    public enum WineType
    {
        RED, WHITE, ROSE, SPARKLING
    }

    // Derived Class: Wine
    public class Wine : Collectible
    {
        public double PricePerGlass { get; set; }
        public string Country { get; set; }
        public WineType Type { get; set; }

         public override string  CollectType
        {
            get { return $"{Type.ToString().ToLower()} wine"; }
        }


        // Constructor
        public Wine(string name, int yearOfOrigin, double price, double pricePerGlass, string country, WineType type)
            : base(name, yearOfOrigin, price)
        {
            PricePerGlass = pricePerGlass;
            Country = country;
            Type = type;
        }

        // ToString method
        public override string ToString()
        {
            return $"{Name} ({Country})";
        }
    }
}