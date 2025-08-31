public class Wine : Collectible
{
    public enum WineType{RED,WHITE,ROSE,SPARKLING}

    public double PricePerGlass {get;set;}

    public string Country {get;set;}

    public WineType Type {get;set;}


    public Wine(string name,int yearoforigin, double price, WineType type, double priceperglass,string country)
     :base(name,yearoforigin,price)
    {
        Type = type;
        PricePerGlass = priceperglass;
        Country = country;
    }


    public override string ToString()
    {
        return $"Name: {Name}, Country{Country}";
    }


    public override string CollectType
    {
        get {return "wine";}
    }
    





}