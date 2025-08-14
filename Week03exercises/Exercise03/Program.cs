using Vehicles.models;     // Importeert de modellen zoals Boat, Cars, Vehicle
using Vehicles.Interface;  // Importeert de interface IRefuelable

// Maak een Boat-object (b1) aan via de Vehicle-basisreferentie
// Parameters: snelheid 120 km/u, kleur "green", type water "saltywater"
Vehicle b1 = new Boat(120, "green", "saltywater");
b1.DescribeVehicle(); // Roept de beschrijvingsmethode aan (returnwaarde wordt hier niet gebruikt)

// Tweede Boat-object (b2) met andere kleur en type water
Vehicle b2 = new Boat(120, "red", "yellowwater");
b2.DescribeVehicle();

// Maak een Cars-object (c1) aan via de Vehicle-basisreferentie
// Parameters: snelheid 120 km/u, kleur "green", 4 wielen
Vehicle c1 = new Cars(120, "green", 4);
c1.DescribeVehicle();

// Tweede Cars-object (c2) met andere waarden
Vehicle c2 = new Cars(240, "blue", 8);
c2.DescribeVehicle();

// Maak een lijst van voertuigen (allemaal van type Vehicle, maar met verschillende subklassen)
List<Vehicle> coolvehicles = new List<Vehicle> { b1, b2, c1 };

// Loop door elk voertuig in de lijst
foreach (Vehicle coolvehicle in coolvehicles)
{
    // Controleer of het voertuig de interface IRefuelable implementeert
    if (coolvehicle is IRefuelable Refuel)
    {
        // Als het voertuig refuelable is, toon dit en roep Refuel() aan
        Console.WriteLine($"{coolvehicle} is refuelable");
        Refuel.Refuel();
    }
    else
    {
        // Als het voertuig niet refuelable is, toon dit
        Console.WriteLine($"{coolvehicle} is not refuelable ");
    }
}
