namespace Ct.Ai.Models
{

    public class Car : Vehicle, IRefuel
    {
        public int NumberOfWheels { get; set; }


        public Car(string color, double speed, int numberofwheels) : base(color, speed)
        {
            NumberOfWheels = numberofwheels;

        }

        public override string DescribeVehicle()
        {
            return $" The car has this {Color} the car has this Speed {Speed} and  this many number of wheels {NumberOfWheels}";
        }

        

         public void Refuel()
        {
            Console.WriteLine("This car is getting refueled.");
        }




    }

    
    



}