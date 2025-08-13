namespace Ct.Ai.Models

{
    public class Address
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public int Zipcode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $" {Street}, {HouseNumber} , {Zipcode}, {City}, {Country}";
        }
    }

}