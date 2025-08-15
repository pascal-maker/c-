// Define the namespace for smartphone models
namespace smartphones.models;

// Define the SmartPhone class to represent a smartphone entity
public class SmartPhone
{
    // Property to store the unique identifier of the smartphone
    public int Id { get; set; }

    // Property to store the brand name (e.g., Apple, Samsung)
    public string Brand { get; set; }

    // Property to store the model type (e.g., iPhone 13, Galaxy S21)
    public string Type { get; set; }

    // Property to store the year when the smartphone was released
    public int ReleaseYear { get; set; }

    // Property to store the starting price of the smartphone
    public int StartPrice { get; set; }

    // Property to store the operating system (e.g., iOS, Android)
    public string OperatingSystem { get; set; }

    // Default constructor - allows creating SmartPhone objects without parameters
    // This is needed for object initializer syntax like: new SmartPhone { Id = 1, ... }
    public SmartPhone() { }

    // Parameterized constructor - allows creating SmartPhone objects with all properties
    // This is useful when you have all the data ready
    public SmartPhone(int id, string brand, string type, int releaseyear, int startprice, string operatingsystem)
    {
        // Assign the constructor parameters to the corresponding properties
        Id = id;                    // Set the ID property
        Brand = brand;              // Set the Brand property
        Type = type;                // Set the Type property
        ReleaseYear = releaseyear;  // Set the ReleaseYear property
        StartPrice = startprice;    // Set the StartPrice property
        OperatingSystem = operatingsystem; // Set the OperatingSystem property
    }

    // Override the ToString method to provide a custom string representation
    // This is called when you use Console.WriteLine(smartphone) or smartphone.ToString()
    public override string ToString()
    {
        // Return a formatted string with all smartphone details
        return $" The smartphone has a ID:{Id}, a Brand: {Brand}Type:{Type},ReleaseYear:{ReleaseYear},StartPrice:{StartPrice},OperatingSystem:{OperatingSystem}";
    }
}