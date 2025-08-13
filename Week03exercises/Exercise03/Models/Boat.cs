namespace Ct.Ai.Models
{

    public class Boat : Vehicle
    {
        public string TypeOfWater { get; set; }


        public Boat(string color, double speed, string typeofwater) : base(color, speed)
        {
            TypeOfWater = typeofwater;

        }

        public override string DescribeVehicle()
        {
            return $"A boat has a certain color {Color} it has a speed of {Speed} km and drives around in this {TypeOfWater}.";
        }

        




    }
    



}