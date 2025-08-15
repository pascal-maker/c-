// Import the SmartPhone model to use in this interface
using smartphones.models;
// Import the repository interface to reference it
using smartphones.Repositories;

// Define the namespace for service interfaces
namespace smartphones.Services;

// Define the interface for smartphone service operations
// This interface defines the contract for business logic operations on smartphones
// The service layer acts as an intermediary between the UI (Program.cs) and the data layer (Repository)
public interface ISmartPhoneService
{
    // Method to retrieve all smartphones
    // This delegates to the repository but could include business logic like filtering or sorting
    List<SmartPhone> GetSmartPhones();

    // Method to add a new smartphone
    // This could include validation logic before delegating to the repository
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