// Import the necessary namespaces to use the models, repositories, and services
using smartphones.models;
using smartphones.Repositories;
using smartphones.Services;

// Create instances of the repository and service classes
// This is where dependency injection happens - we create the repository first, then pass it to the service
var smartphoneRepository = new SmartPhoneRepository();  // Create the data access layer
var smartphoneService = new SmartPhoneService(smartphoneRepository);  // Create the business logic layer

// Boolean variable to control the main program loop
// When this becomes true, the program will exit
bool exit = false;

// Main program loop - this runs until the user chooses to exit
while (!exit)
{
    // Clear the console screen to show a clean menu
    Console.Clear();
    
    // Display the main menu options
    Console.WriteLine("=== Smartphone Management System ===");
    Console.WriteLine("1. View All Smartphones");
    Console.WriteLine("2. Add New Smartphone");
    Console.WriteLine("3. Search by Brand");
    Console.WriteLine("4. Search by Type");
    Console.WriteLine("5. Get smartphone by ID");
    Console.WriteLine("6. Exit");
    Console.Write("\nEnter your choice (1-6): ");

    // Read the user's choice from the console
    string choice = Console.ReadLine();

    // Switch statement to handle different menu choices
    switch (choice)
    {
        case "1":
            // Call the method to display all smartphones
            GetSmartPhones(smartphoneService);
            break;
        case "2":
            // Call the method to add a new smartphone
            AddSmartPhone(smartphoneService);
            break;
        case "3":
            // Call the method to search by brand
            GetSmartPhoneByBrand(smartphoneService);
            break;
        case "4":
            // Call the method to search by type
            GetSmartPhoneByType(smartphoneService);
            break;
        case "5":
            // Call the method to search by ID
            GetSmartPhoneById(smartphoneService);
            break;
        case "6":
            // Set exit flag to true to end the program
            exit = true;
            Console.WriteLine("Goodbye!");
            break;
        
        default:
            // Handle invalid menu choices
            Console.WriteLine("Invalid choice. Press any key to continue...");
            Console.ReadKey();
            break;
    }
}

// Helper method to display all smartphones
// This method takes the service as a parameter (dependency injection)
static void GetSmartPhones(SmartPhoneService smartphoneService)
{
    // Clear the console and show a header
    Console.Clear();
    Console.WriteLine("=== All Smartphones ===\n");

    // Get all smartphones from the service (which gets them from the repository)
    var smartphones = smartphoneService.GetSmartPhones();

    // Check if there are any smartphones to display
    if (smartphones.Count == 0)
    {
        Console.WriteLine("No smartphones found.");
    }
    else
    {
        // Loop through each smartphone and display it
        // The ToString() method is automatically called when we use Console.WriteLine(smartphone)
        foreach (var smartphone in smartphones)
        {
            Console.WriteLine(smartphone);
        }
    }

    // Display the total count of smartphones
    Console.WriteLine($"\nTotal smartphones: {smartphones.Count}");
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();  // Wait for user to press a key before continuing
}

// Helper method to add a new smartphone
static void AddSmartPhone(SmartPhoneService smartphoneService)
{
    // Clear the console and show a header
    Console.Clear();
    Console.WriteLine("=== Add New Smartphone ===\n");
    
    // Use try-catch to handle any errors that might occur during input
    try
    {
        // Get smartphone ID from user
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);  // Convert string to int, use empty string if null
        
        // Get smartphone brand from user
        Console.Write("Enter Brand: ");
        string brand = Console.ReadLine() ?? string.Empty;
        
        // Get smartphone type from user
        Console.Write("Enter Type: ");
        string type = Console.ReadLine() ?? string.Empty;
        
        // Get release year from user
        Console.Write("Enter the release year: ");
        int releaseyear = int.Parse(Console.ReadLine() ?? string.Empty);

        // Get start price from user
        Console.Write("Enter the start price: ");
        int startprice = int.Parse(Console.ReadLine() ?? string.Empty);
        
        // Get operating system from user
        Console.Write("Enter Operating System: ");
        string operatingsystem = Console.ReadLine() ?? string.Empty;
        
        // Validate that required fields are not empty
        if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(operatingsystem))
        {
            Console.WriteLine("Brand, Type and Operating System are required!");
        }
        else
        {
            // Create a new SmartPhone object using object initializer syntax
            var newSmartPhone = new SmartPhone
            {
                Id = id,
                Brand = brand,
                Type = type,
                ReleaseYear = releaseyear,
                StartPrice = startprice,
                OperatingSystem = operatingsystem
            };

            // Add the smartphone through the service (which will save it to the CSV file)
            smartphoneService.AddSmartPhone(newSmartPhone);
            Console.WriteLine("\nSmartphone added successfully!");
        }
    }
    catch (Exception ex)
    {
        // Display any error that occurred during the process
        Console.WriteLine($"Error adding smartphone: {ex.Message}");
    }
    
    // Wait for user to press a key before continuing
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

// Helper method to search for a smartphone by ID
static void GetSmartPhoneById(SmartPhoneService smartphoneService)
{
    // Clear the console and show a header
    Console.Clear();
    Console.WriteLine("=== Find Smartphone by ID ===\n");
    
    // Get the ID from user
    Console.Write("Enter smartphone ID: ");
    
    // Try to parse the input as an integer
    // TryParse returns true if successful, false if it fails
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        // Search for the smartphone using the service
        var smartphone = smartphoneService.GetSmartPhoneById(id);
        
        // Check if a smartphone was found
        if (smartphone != null)
        {
            Console.WriteLine($"\nFound smartphone:");
            Console.WriteLine(smartphone);  // Uses the ToString() method
        }
        else
        {
            Console.WriteLine($"\nNo smartphone found with ID {id}");
        }
    }
    else
    {
        // Handle invalid input (non-numeric)
        Console.WriteLine("Invalid ID format.");
    }
    
    // Wait for user to press a key before continuing
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

// Helper method to search for a smartphone by brand
static void GetSmartPhoneByBrand(SmartPhoneService smartphoneService)
{
    // Clear the console and show a header
    Console.Clear();
    Console.WriteLine("=== Search Smartphone by Brand ===\n");
    
    // Get the brand from user
    Console.Write("Enter smartphone brand: ");
    string? brand = Console.ReadLine();  // Read the input as a string
    
    // Check if the input is not null or empty
    if (!string.IsNullOrEmpty(brand))
    {
        // Search for the smartphone using the service
        var smartphone = smartphoneService.GetSmartPhoneByBrand(brand);
        
        // Check if a smartphone was found
        if (smartphone != null)
        {
            Console.WriteLine($"\nFound smartphone:");
            Console.WriteLine(smartphone);  // Uses the ToString() method
        }
        else
        {
            Console.WriteLine($"\nNo smartphone found with brand {brand}");
        }
    }
    else
    {
        // Handle empty input
        Console.WriteLine("Invalid brand format.");
    }
    
    // Wait for user to press a key before continuing
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

// Helper method to search for a smartphone by type
static void GetSmartPhoneByType(SmartPhoneService smartphoneService)
{
    // Clear the console and show a header
    Console.Clear();
    Console.WriteLine("=== Search Smartphone by Type ===\n");
    
    // Get the type from user
    Console.Write("Enter smartphone type: ");
    string? type = Console.ReadLine();  // Read the input as a string
    
    // Check if the input is not null or empty
    if (!string.IsNullOrEmpty(type))
    {
        // Search for the smartphone using the service
        var smartphone = smartphoneService.GetSmartPhoneByType(type);
        
        // Check if a smartphone was found
        if (smartphone != null)
        {
            Console.WriteLine($"\nFound smartphone:");
            Console.WriteLine(smartphone);  // Uses the ToString() method
        }
        else
        {
            Console.WriteLine($"\nNo smartphone found with type {type}");
        }
    }
    else
    {
        // Handle empty input
        Console.WriteLine("Invalid type format.");
    }
    
    // Wait for user to press a key before continuing
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}