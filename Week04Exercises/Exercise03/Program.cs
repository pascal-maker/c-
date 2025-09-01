using System;

using System.Collections.Generic;
using beer.Exceptions;

namespace beer.Models
{
    /// <summary>
    /// Program - Hoofdklasse voor het testen van de Beer functionaliteit
    /// Demonstreert het maken van Beer objecten en exception handling
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main methode - Entry point van het programma
        /// Test verschillende scenario's voor het maken van Beer objecten
        /// Toont exception handling voor validatie fouten
        /// </summary>
        /// <param name="args">Command line argumenten (niet gebruikt)</param>
        public static void Main(string[] args)
        {
            // Maak een lijst om alle succesvol aangemaakte bieren op te slaan
            var beers = new List<Beer>();

            // Test 1: Negatief alcohol percentage (zou een exception moeten gooien)
            try {
                beers.Add(new Beer("Jupiler","delirum",-1.0,"blond"));
            }
            catch(BeerException ex) {
                Console.WriteLine($"Invalid beer: {ex.Message}");
            }

            // Test 2: Geldig bier (zou succesvol moeten zijn)
            try {
                beers.Add(new Beer("Toutestbienpils","averagerob",8.0,"brown"));
            }
            catch(BeerException ex) {
                Console.WriteLine($"Invalid beer: {ex.Message}");
            }

            // Test 3: Nog een negatief alcohol percentage (zou een exception moeten gooien)
            try {
                beers.Add(new Beer("Mannekenpis","abinbev",-1.0,"blond"));
            }
            catch(BeerException ex) {
                Console.WriteLine($"Invalid beer: {ex.Message}");
            }

            // Test 4: Lege naam (zou een exception moeten gooien)
            try {
                beers.Add(new Beer("","abinbev",9.0,"blond"));
            }
            catch(BeerException ex) {
                Console.WriteLine($"Invalid beer: {ex.Message}");
            }

            // Toon alle succesvol aangemaakte bieren
            Console.WriteLine("\nSuccesvol aangemaakte bieren:");
            foreach (var beer in beers)
            {
                Console.WriteLine(beer);
                Console.WriteLine();
            }
        }
    }
}