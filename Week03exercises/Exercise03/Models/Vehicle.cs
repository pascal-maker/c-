namespace Ct.Ai.Models
{
    public abstract class Vehicle
    {
        public string Color { get; set; }
        public double Speed { get; set; }

        public Vehicle(string color, double speed)
        {
            Color = color;
            Speed = speed;
        }

        public abstract string DescribeVehicle();




        public override string ToString()
        {
            return $" Color: {Color}, Speed: {Speed}";
        }



    }
    
    


}