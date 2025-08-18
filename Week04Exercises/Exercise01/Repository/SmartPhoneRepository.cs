// Import necessary namespaces
using System.Runtime.CompilerServices;
using smartphones.models;

// Define the namespace for repository implementations
namespace smartphones.Repositories;

// Implement the ISmartPhoneRepository interface
// This class handles all data access operations for smartphones
public class SmartPhoneRepository : ISmartPhoneRepository
{
    // Define the path to the CSV file as a constant
    // This file stores all smartphone data
    private const string csvFile = "data/smartphones.csv";

    // Implementation of GetSmartPhones method
    // This method reads all smartphones from the CSV file
    public List<SmartPhone> GetSmartPhones()
    {
        // Create a new list to store smartphone objects
        List<SmartPhone> smartphones = new List<SmartPhone>();

        // Read all lines from the CSV file into an array
        // Each line represents one smartphone record
        string[] lines = File.ReadAllLines(csvFile);

        // Loop through all lines starting from index 1 (skip the header row)
        // Index 0 contains column names: "Id,brand,type,release year,start price,operating system"
        for (int i = 1; i < lines.Length; i++)
        {
            // Get the current line
            string line = lines[i];
            
            // Split the line by comma to separate the different fields
            // This creates an array where each element is one field
            string[] entries = line.Split(',');

            // Check if we have at least 6 fields (Id, brand, type, release year, start price, operating system)
            if (entries.Length >= 6)
            {
                // Create a new SmartPhone object using object initializer syntax
                // This uses the default constructor and sets properties
                SmartPhone newSmartPhone = new SmartPhone
                {
                    Id = int.Parse(entries[0].Trim()),           // Convert string to int for ID
                    Brand = entries[1].Trim(),                   // Brand is the second column
                    Type = entries[2].Trim(),                    // Type is the third column
                    ReleaseYear = int.Parse(entries[3].Trim()),  // Convert string to int for release year
                    StartPrice = int.Parse(entries[4].Trim()),   // Convert string to int for start price
                    OperatingSystem = entries[5].Trim()          // Operating system is the sixth column
                };
                
                // Add the created smartphone to our list
                smartphones.Add(newSmartPhone);
            }
        }

        // Return the complete list of smartphones
        return smartphones;
    }

    // Implementation of AddSmartPhone method
    // This method adds a new smartphone to the CSV file
    public void AddSmartPhone(SmartPhone smartphone)
    {
        // Check if the smartphone parameter is null and throw an exception if it is
        // This prevents null reference exceptions later in the code
        ArgumentNullException.ThrowIfNull(smartphone);

        // Read all existing smartphones from the CSV file
        var smartphones = GetSmartPhones();
        
        // Add the new smartphone to the list in memory
        smartphones.Add(smartphone);

        // Create a new list to hold all lines that will be written to the CSV file
        var lines = new List<string>();
        
        // Add the header row first (column names)
        lines.Add("Id,brand,type,release year,start price,operating system");
        
        // Loop through all smartphones (including the new one) and create CSV lines
        foreach (var phone in smartphones)
        {
            // Create a CSV line by joining all smartphone properties with commas
            // Format: ID,Brand,Type,ReleaseYear,StartPrice,OperatingSystem
            lines.Add($"{phone.Id},{phone.Brand},{phone.Type},{phone.ReleaseYear},{phone.StartPrice},{phone.OperatingSystem}");
        }
        
        // Write all lines back to the CSV file, overwriting the existing content
        // This ensures the new smartphone is permanently saved
        File.WriteAllLines(csvFile, lines);
    }

    // Implementation of GetSmartPhoneById method
    // This method finds a smartphone by its unique ID
    public SmartPhone? GetSmartPhoneById(int id)
    {
        // Get all smartphones from the CSV file
        var smartphones = GetSmartPhones();
        
        // Use LINQ to find the first smartphone with matching ID
        // FirstOrDefault returns the first match or null if no match is found
        return smartphones.FirstOrDefault(s => s.Id == id);
    }

    // Implementation of GetSmartPhoneByBrand method
    // This method finds a smartphone by its brand name
    public SmartPhone? GetSmartPhoneByBrand(string brand)
    {
        // Get all smartphones from the CSV file
        var smartphones = GetSmartPhones();
        
        // Use LINQ to find the first smartphone with matching brand
        // String comparison is case-sensitive by default
        return smartphones.FirstOrDefault(s => s.Brand == brand);
    }

    // Implementation of GetSmartPhoneByType method
    // This method finds a smartphone by its type/model
    public SmartPhone? GetSmartPhoneByType(string type)
    {
        // Get all smartphones from the CSV file
        var smartphones = GetSmartPhones();
        
        // Use LINQ to find the first smartphone with matching type
        // String comparison is case-sensitive by default
        return smartphones.FirstOrDefault(s => s.Type == type);
    }
}
