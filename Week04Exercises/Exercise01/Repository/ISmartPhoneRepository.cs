// Import the SmartPhone model to use in this interface
using smartphones.models;

// Define the namespace for repository interfaces
namespace smartphones.Repositories;

// Define the interface for smartphone repository operations
// This interface defines the contract that any smartphone repository must implement
public interface ISmartPhoneRepository
{
    // Method to retrieve all smartphones from the data source
    // Returns a list of all SmartPhone objects
    List<SmartPhone> GetSmartPhones();

    // Method to add a new smartphone to the data source
    // Takes a SmartPhone object as parameter
    void AddSmartPhone(SmartPhone smartphone);

    // Method to find a smartphone by its unique ID
    // Returns the SmartPhone if found, null if not found
    // The ? makes the return type nullable (can return null)
    SmartPhone? GetSmartPhoneById(int id);

    // Method to find a smartphone by its brand name
    // Returns the first SmartPhone with matching brand, null if not found
    SmartPhone? GetSmartPhoneByBrand(string brand);

    // Method to find a smartphone by its type/model
    // Returns the first SmartPhone with matching type, null if not found
    SmartPhone? GetSmartPhoneByType(string type);
}
