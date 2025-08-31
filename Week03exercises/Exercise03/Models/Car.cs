using Vehicles.Interface; // Importeert de namespace waarin de IRefuelable-interface zich bevindt

namespace Vehicles.models // Namespace waarin de Cars-klasse zich bevindt
{
    // De Cars-klasse erft van Vehicle en implementeert de IRefuelable-interface
    public class Cars : Vehicle, IRefuelable
    {
        // Eigenschap (property) die het aantal wielen van de auto beschrijft
        public int NumberOfWheels { get; set; }

        // Constructor voor Cars
        // Parameters:
        //   speed           -> Snelheid van de auto in km/u
        //   color           -> Kleur van de auto
        //   numberofwheels  -> Aantal wielen van de auto
        // De constructor roept de base-constructor van Vehicle aan om Speed en Color in te stellen
        public Cars(int speed, string color, int numberofwheels) : base(speed, color)
        {
            // Stel de eigenschap NumberOfWheels in met de waarde uit de parameter
            NumberOfWheels = numberofwheels;
        }

        // Override van de DescribeVehicle()-methode uit Vehicle
        // Geeft een beschrijving van de auto terug
        public override string DescribeVehicle()
        {
            return $"A Car has a certain color {Color} it has a speed of {Speed} km and has this amount of wheels  {NumberOfWheels}.";
        }

        // Override van de ToString()-methode
        // Retourneert een string met de eigenschappen van de auto
        public override string ToString()
        {
            return $" Color: {Color},  Speed: {Speed}, NumberOfWheels: {NumberOfWheels}";
        }

        // Implementatie van de refuel()-methode uit de IRefuelable-interface
        // Deze methode simuleert het tanken van de auto
        public void refuel()
        {
            Console.WriteLine(" The car is getting refueled");
        }
    }
}