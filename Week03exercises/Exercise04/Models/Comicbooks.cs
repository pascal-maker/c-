namespace Ct.Ai.Models
{



    public class ComicBook : Collectible
    {
        public string Publisher { get; set; }
        public string Author { get; set; }


         public override string  CollectType
        {
            get { return "comic book"; }
        }

        // Constructor
        public ComicBook(string name, int yearOfOrigin, double price, string publisher, string author)
            : base(name, yearOfOrigin, price)
        {
            Publisher = publisher;
            Author = author;
        }

        // ToString method
         public override string ToString()
        {
            return $" Name:{Name},YearOfOrigin:{YearOfOrigin},Price:{Price},Author: {Author}";
        }
    }

}