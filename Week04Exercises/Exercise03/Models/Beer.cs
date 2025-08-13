using Exercise03.Models;

namespace Exercise03.Models
{
    public class Beer
    {
        public string Name { get; set; }
        public string Brewery { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public string Color { get; set; }

        public Beer(string name, string brewery, decimal alcoholPercentage, string color)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BeerException(
                    "Name cannot be empty.",
                    nameof(name),
                    name ?? string.Empty
                );
            }

            if (string.IsNullOrWhiteSpace(brewery))
            {
                throw new BeerException(
                    "Brewery cannot be empty.",
                    nameof(brewery),
                    brewery ?? string.Empty
                );
            }

            if (alcoholPercentage < 0)
            {
                throw new BeerException(
                    "Alcohol percentage cannot be negative.",
                    nameof(alcoholPercentage),
                    alcoholPercentage.ToString()
                );
            }

            if (string.IsNullOrWhiteSpace(color))
            {
                throw new BeerException(
                    "Color cannot be empty.",
                    nameof(color),
                    color ?? string.Empty
                );
            }

            Name = name;
            Brewery = brewery;
            AlcoholPercentage = alcoholPercentage;
            Color = color;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Brewery: {Brewery}, AlcoholPercentage: {AlcoholPercentage}, Color: {Color}";
        }
    }
}
