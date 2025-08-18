namespace Vehicles.models // Namespace waarin de Vehicle-klasse zich bevindt
{
    // Vehicle is een abstracte klasse
    // Dit betekent dat je er geen directe objecten van kan maken
    // en dat subklassen verplicht bepaalde methodes moeten implementeren
    public abstract class Vehicle
    {
        // Eigenschap (property) voor de snelheid van het voertuig in km/u
        public int Speed { get; set; }

        // Eigenschap (property) voor de kleur van het voertuig
        public string Color { get; set; }

        // Constructor voor Vehicle
        // Parameters:
        //   speed -> snelheid van het voertuig
        //   color -> kleur van het voertuig
        public Vehicle(int speed, string color)
        {
            Speed = speed;   // Stel de snelheid in
            Color = color;   // Stel de kleur in
        }

        // Abstracte methode die door alle subklassen moet worden overschreven
        // Deze methode moet een beschrijving van het voertuig teruggeven
        public abstract string DescribeVehicle();
    }
}
