// Import the SmartPhone model to use in this service
using smartphones.models;
// Import the repository interface to use dependency injection
using smartphones.Repositories;

// Define the namespace for service implementations
namespace smartphones.Services;

// Implement the ISmartPhoneService interface
// This class contains the business logic for smartphone operations
// It acts as an intermediary between the UI (Program.cs) and the data layer (Repository)
public class SmartPhoneService : ISmartPhoneService
{
    // Private field to store the repository instance
    // This is injected through the constructor (dependency injection)
    // readonly means this field can only be set once (in the constructor)
    private readonly ISmartPhoneRepository _smartphoneRepository;

    // Constructor that takes a repository as a parameter
    // This is called dependency injection - the service depends on the repository
    // The repository is passed from outside (Program.cs) rather than created inside
    public SmartPhoneService(ISmartPhoneRepository smartphoneRepository)
    {
        // Store the injected repository in the private field
        _smartphoneRepository = smartphoneRepository;
    }

    // Implementation of GetSmartPhones method
    // This method delegates directly to the repository
    // In a real application, you might add business logic here like filtering, sorting, or caching
    public List<SmartPhone> GetSmartPhones()
    {
        // Call the repository method and return the result
        return _smartphoneRepository.GetSmartPhones();
    }

    // Implementation of GetSmartPhoneById method
    // This method delegates to the repository but could include additional business logic
    public SmartPhone? GetSmartPhoneById(int id)
    {
        // Call the repository method and return the result
        // The ? in the return type allows this method to return null
        return _smartphoneRepository.GetSmartPhoneById(id);
    }

    // Implementation of AddSmartPhone method
    // This method could include validation logic before delegating to the repository
    public void AddSmartPhone(SmartPhone smartphone)
    {
        // In a real application, you might add validation here:
        // - Check if smartphone is not null
        // - Validate that required fields are not empty
        // - Check if ID is unique
        // - Validate price is positive
        // - etc.

        // For now, just delegate to the repository
        _smartphoneRepository.AddSmartPhone(smartphone);
    }

    // Implementation of GetSmartPhoneByBrand method
    // This method delegates to the repository
    public SmartPhone? GetSmartPhoneByBrand(string brand)
    {
        // Call the repository method and return the result
        return _smartphoneRepository.GetSmartPhoneByBrand(brand);
    }

    // Implementation of GetSmartPhoneByType method
    // This method delegates to the repository
    public SmartPhone? GetSmartPhoneByType(string type)
    {
        // Call the repository method and return the result
        return _smartphoneRepository.GetSmartPhoneByType(type);
    }
}
