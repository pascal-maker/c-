namespace Vehicles.models // Namespace waarin de Boat-klasse zich bevindt
{
    // De Boat-klasse erft van de Vehicle-basisclass
    public class Boat : Vehicle
    { 
        // Eigenschap (property) die het type water beschrijft waarin de boot vaart (bijvoorbeeld "river", "sea")
        public string TypeOfWater { get; set; }

        // Constructor voor Boat
        // Parameters:
        //   speed        -> De snelheid van de boot in km/u
        //   color        -> De kleur van de boot
        //   typeofwater  -> Het type water waarin de boot zich bevindt
        // De constructor roept de base-constructor van Vehicle aan om Speed en Color in te stellen
        public Boat(int speed, string color, string typeofwater) : base(speed, color)
        {
            // Stel de eigenschap TypeOfWater in
            TypeOfWater = typeofwater;
        }

        // Override van de abstracte of virtuele methode DescribeVehicle() uit Vehicle
        // Geeft een beschrijving van de boot terug
        public override string DescribeVehicle()
        {
            return $"A boat has a certain color {Color} it has a speed of {Speed} km and drives around in this {TypeOfWater}.";
        }

        // Override van de ToString() methode
        // Zorgt ervoor dat als je een Boat-object print, de kleur, snelheid en het type water worden getoond
        public override string ToString()
        {
            return $" Color: {Color},  Speed: {Speed}, TypeOfWater: {TypeOfWater}";
        }
    }
}
