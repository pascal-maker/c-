namespace Ct.Ai.Models

{
    public abstract class Collectible : IComparable<Collectible>
    {
        public string Name { get; set; }

        public int YearOfOrigin { get; set; }

        public double Price { get; set; }

        public double StartBidPrice
        {
        get { return Price * 0.80; }
        }

        public abstract string CollectType { get; }


        public Collectible(string name, int yearoforigin, double price)
        {
            Name = name;
            YearOfOrigin = yearoforigin;
            Price = price;

        }


        public int CompareTo(Collectible other)
        {
            if (other == null) return 1;
            return Name.CompareTo(other.Name);
        }

        public override abstract string ToString();



        

        
        
        
        



        


        





    }
}   