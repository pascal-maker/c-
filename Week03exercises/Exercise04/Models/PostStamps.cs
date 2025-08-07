namespace Ct.Ai.Models
{

    public class PostStamp : Collectible
    {
        public string Image { get; set; }

          public override string  CollectType
        {
            get { return "Post Stamp"; }
        }

        // Constructor
        public PostStamp(string name, int yearOfOrigin, double price, string image)
            : base(name, yearOfOrigin, price)
        {
            Image = image;
        }

        // ToString method
        public override string ToString()
        {
            return $" Name:{Name},YearOfOrigin:{YearOfOrigin},Price:{Price},Image: {Image}";
        }
    }

}