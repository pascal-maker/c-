namespace CTANDAI.CarReservationSystem.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public bool Electric { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
    }
}