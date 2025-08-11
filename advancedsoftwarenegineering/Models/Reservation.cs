namespace CTAndAI.CarReservationSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CarId { get; set; }
        public decimal CustomerName { get; set; }
        public int Duration { get; set; }
        public  decimal Cost{ get; set; }

        public bool ElectricRequired {get;set;}

        
    }
}
    