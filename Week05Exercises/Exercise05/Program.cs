using System;
using System.Collections.Generic;
using System.Linq;
using Exercise05.Models;

namespace Exercise05.Models
{
    /// <summary>
    /// Program - Hoofdklasse voor LINQ OfType() demonstratie
    /// Toont hoe je specifieke types kunt filteren uit een polymorphe lijst
    /// Demonstreert LINQ, polymorphisme, en type-safe filtering
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main methode - Entry point van de applicatie
        /// Demonstreert het gebruik van LINQ OfType() voor type filtering
        /// </summary>
        static void Main()
        {
            // ========================================
            // STAP 1: Polymorphe lijst maken
            // ========================================
            // Maak een lijst van IVehicle interface type
            // Kan verschillende concrete voertuig types bevatten (polymorphisme)
            List<IVehicle> vehicles = new List<IVehicle>()
            {
                new Caddy(),        // 1 caddy
                new Motorcycle(),   // 1 motorcycle  
                new Truck(),        // 1e truck
                new Truck()         // 2e truck
            };
            // Totaal: 4 voertuigen van 3 verschillende types

            // ========================================
            // STAP 2: LINQ OfType() gebruiken
            // ========================================
            // OfType<T>() filtert alleen objecten van type T uit de lijst
            // Type-safe: automatische casting van IVehicle naar Caddy
            // Geen exceptions als types niet matchen
            var caddies = vehicles.OfType<Caddy>().ToList();
            
            // Van 4 voertuigen blijft alleen 1 Caddy over
            // Motorcycles en Trucks worden gefilterd weg

            // ========================================
            // STAP 3: Resultaten tonen
            // ========================================
            // Toon hoeveel caddies gevonden zijn
            Console.WriteLine($"Found {caddies.Count} caddies:");
            
            // Loop door alle gevonden caddies
            foreach (var caddy in caddies)
            {
                // Roep Drive() aan - specifieke Caddy implementatie wordt uitgevoerd
                caddy.Drive(); // Output: "Driving a caddie"
            }

            // ========================================
            // EXTRA: Andere LINQ OfType() voorbeelden
            // ========================================
            // Je zou ook andere types kunnen filteren:
            // var trucks = vehicles.OfType<Truck>().ToList();         // 2 trucks
            // var motorcycles = vehicles.OfType<Motorcycle>().ToList(); // 1 motorcycle
        }
    }
}