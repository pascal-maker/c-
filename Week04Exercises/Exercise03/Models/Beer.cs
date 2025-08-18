// Import the System namespace for basic functionality
using System;
// Import the custom exceptions namespace
using beer.Exceptions;

// Define the namespace for beer models
namespace beer.Models;

// Define the Beer class to represent a beer entity
public class Beer
{
    // Property to store the name of the beer
    public string Name { get; set; }
    // Property to store the brewery that makes the beer
    public string Brewery { get; set; }

    // Property to store the alcohol percentage of the beer
    public decimal AlcoholPercentage { get; set; }

    // Property to store the color of the beer
    public string Color { get; set; }

    // Constructor to create a new Beer object with validation
    public Beer(string name, string brewery, decimal alcoholpercentage, string color)
    {
        // Check if the name is null, empty, or contains only whitespace
        if (string.IsNullOrWhiteSpace(name))
        {
            // Throw custom exception if name is invalid
            throw new Beerexception("name cannot be empty.", nameof(name), name ?? string.Empty);
        }

        // Check if the brewery is null, empty, or contains only whitespace
        if (string.IsNullOrWhiteSpace(brewery))
        {
            // Throw custom exception if brewery is invalid
            throw new Beerexception("Brewery cannot be empty.", nameof(brewery), brewery ?? string.Empty);

            // Empty line for spacing
        }

        // Check if the alcohol percentage is negative
        if (alcoholpercentage < 0)
        {
            // Throw custom exception if alcohol percentage is negative
            throw new Beerexception("alcohol percentage canot be negative.", nameof(alcoholpercentage), alcoholpercentage.ToString());
        }

        // Check if the color is null, empty, or contains only whitespace
        if (string.IsNullOrWhiteSpace(color))
        {
            // Throw custom exception if color is invalid
            throw new Beerexception("color cannot be empty.", nameof(color), color ?? string.Empty);

            // Empty line for spacing
        }

        // Assign the validated name to the Name property
        Name = name;
        // Assign the validated brewery to the Brewery property
        Brewery = brewery;
        // Assign the validated alcohol percentage to the AlcoholPercentage property
        AlcoholPercentage = alcoholpercentage;
        // Assign the validated color to the Color property
        Color = color;

        // Empty lines for spacing

    }

    // Override the ToString method to provide a custom string representation
    public override string ToString()
    {
        // Return a formatted string with all beer properties
        return $" Name:{Name},Brewery:{Brewery}, AlcoholPercentage:{AlcoholPercentage},Color:{Color}";
    }

}