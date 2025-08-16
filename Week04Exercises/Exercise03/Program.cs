// Import the System namespace for basic functionality
using System;
// Import the System.Collections.Generic namespace for List<T>
using System.Collections.Generic;
// Import the custom exceptions namespace
using beer.Exceptions;

// Define the namespace for beer models
namespace beer.Models
{
    // Define the main Program class
    public class Program
    {
        // Main entry point of the application
        public static void Main(string[] args)
        {
            // Create a new list to store Beer objects
            var beers = new List<Beer>();

            // Empty lines for spacing

            // Try to add a beer with invalid negative alcohol percentage
            try { beers.Add(new Beer("jupla", "delirium", -1.0m, "yellow")); }
            // Catch the custom beer exception and display error message
            catch (Beerexception ex) { Console.WriteLine($"Invalid beer: {ex.Message}"); }

            // Try to add a valid beer
            try { beers.Add(new Beer("yessbeer", "stella", 8.0m, "blond")); }
            // Catch the custom beer exception and display error message
            catch (Beerexception ex) { Console.WriteLine($"Invalid beer: {ex.Message}"); }

            // Try to add another beer with invalid negative alcohol percentage
            try { beers.Add(new Beer("Kriek", "stekka", -7.0m, "yellow")); }
            // Catch the custom beer exception and display error message
            catch (Beerexception ex) { Console.WriteLine($"Invalid beer: {ex.Message}"); }

            // Empty line for spacing

            // Iterate through all beers in the list
            foreach (var beer in beers)
            {
                // Display each beer using its ToString method
                Console.WriteLine(beer);
                // Add an empty line after each beer
                Console.WriteLine();
            }

            // Empty lines for spacing

            // Empty lines for spacing

            // Empty lines for spacing

            // Empty lines for spacing

        }
    }
}