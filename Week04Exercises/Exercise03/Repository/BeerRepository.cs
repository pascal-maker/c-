// Import the System namespace for basic functionality
using System;
// Import the System.Collections.Generic namespace for List<T>
using System.Collections.Generic;
// Import the System.Globalization namespace for CultureInfo
using System.Globalization;
// Import the System.IO namespace for file operations
using System.IO;
// Import the System.Linq namespace for LINQ operations
using System.Linq;
// Import the custom exceptions namespace
using beer.Exceptions;
// Import the beer models namespace
using beer.Models;

// Define the namespace for beer repositories
namespace beer.Repositories
{
    // Define the BeerRepository class to handle beer data operations
    public class BeerRepository
    {
        // Private field to store the file path for the CSV data
        private readonly string _filePath;
        // Static readonly field for invariant culture info
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        // Constructor to initialize the repository with a file path
        public BeerRepository(string filePath)
        {
            // Assign the provided file path to the private field
            _filePath = filePath;
        }

        // Method to retrieve all beers from the CSV file
        public List<Beer> GetAllBeers()
        {
            // Create a new list to store beer objects
            var beers = new List<Beer>();
            // Check if the file exists, return empty list if not
            if (!File.Exists(_filePath)) return beers;

            // Read all lines from the file and skip the header row
            var lines = File.ReadAllLines(_filePath).Skip(1);

            // Iterate through each line in the file
            foreach (var line in lines)
            {
                // Skip empty or whitespace-only lines
                if (string.IsNullOrWhiteSpace(line)) continue;
                // Split the line by semicolon delimiter
                var parts = line.Split(';');
                // Skip lines that don't have enough parts (less than 5)
                if (parts.Length < 5) continue;

                // Extract and trim the name from the second column
                var name = parts[1].Trim();

                // Extract and trim the brewery from the third column
                var brewery = parts[2].Trim();

                // Extract and trim the color from the fourth column
                var color = parts[3].Trim();

                // Extract alcohol percentage, replace comma with dot for decimal parsing
                var alcoholStr = parts[4].Trim().Replace(',', '.');
                // Try to parse the alcohol string to decimal, skip if parsing fails
                if (!decimal.TryParse(alcoholStr, NumberStyles.Any, Inv, out var alcohol)) continue;
                // Try to create a new beer object with the parsed data
                try
                {
                    // Add the new beer to the list
                    beers.Add(new Beer(name, brewery, alcohol, color));

                }
                // Catch custom beer exceptions and display detailed error information
                catch (Beerexception ex)
                {
                    // Display the error message with field name and value
                    Console.WriteLine($"FOut: {ex.Message} (Field: {ex.WrongFieldName}, Value: {ex.WrongValue})");

                }

                // Catch any other unexpected exceptions
                catch (Exception ex)
                {
                    // Display unexpected error message
                    Console.WriteLine($" Onverwachte fout bij het parsen bier: {ex.Message}");
                }

            }
            // Return the list of successfully parsed beers
            return beers;
        }

        // Empty line for spacing

    }
}
