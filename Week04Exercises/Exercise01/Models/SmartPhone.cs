namespace Ct.Ai.Models
{
    public class Smartphone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int ReleaseYear { get; set; }
        public decimal StartPrice { get; set; }
        public string OperatingSystem { get; set; }

        public override string ToString()
        {
            return $" {Id}. {Brand} {Type} - {ReleaseYear} -€ {StartPrice} - {OperatingSystem} ";
        }
    }
}