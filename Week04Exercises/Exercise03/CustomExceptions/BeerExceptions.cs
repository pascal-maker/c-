// Import the System namespace for basic functionality
using System;
// Define the namespace for beer exceptions
namespace beer.Exceptions;

// Define a custom exception class for beer-related errors
public class Beerexception : Exception
{  
    // Property to store the name of the field that caused the error
    public string WrongFieldName { get; set; }
    // Property to store the invalid value that caused the error
    public string WrongValue { get; set; }

    // Constructor that takes a message, field name, and field value
    public Beerexception(string message, string fieldName, string fieldValue) : base(message)
    {
        // Assign the field name to the WrongFieldName property
        WrongFieldName = fieldName;
        // Assign the field value to the WrongValue property
        WrongValue = fieldValue;
    }
}  
