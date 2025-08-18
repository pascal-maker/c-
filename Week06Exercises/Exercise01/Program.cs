// Import the Person model from the ADO.Models namespace
using ADO.Models;

// Import MySQL data client for database operations
using MySql.Data.MySqlClient;
// Import repository interfaces and implementations
using ADO.Repositories;
// Import service interfaces and implementations
using ADO.Services;

// Create a new instance of PersonRepository for data access operations
var personRepository = new PersonRepository();  // Repository for Person entity operations
// Create a new instance of PersonService, passing the repository as dependency
var personService = new PersonService(personRepository);  // Service layer that uses the repository

// Call the main menu function to start the application
Menu();

// Main menu function that displays options and handles user interaction
void Menu()
{
    // Infinite loop to keep the application running until user chooses to exit
    while (true)
    {
        // Display menu options to the user
        Console.WriteLine("1. Add Person");      // Option to add a new person
        Console.WriteLine("2. Update a person ");         // Option to update an existing person
        Console.WriteLine("3. Delete a person");     // Option to delete a person
        Console.WriteLine("4. Get Person by id");       // Option to get a specific person by ID
        Console.WriteLine("5. Get all persons");        // Option to display all people
        Console.WriteLine("6. Exit");            // Option to exit the application
        Console.Write("Choose an option: ");     // Prompt user for input
        var option = Console.ReadLine();         // Read user's choice from console
        ParseOption(option);                     // Process the user's choice
    }
}

// Function to parse and handle the user's menu choice
void ParseOption(string option)
{
    // Switch statement to route to appropriate function based on user input
    switch (option)
    {
        case "1":
            AddPerson();     // Call function to add a new person
            break;
        case "2":
           UpdatePerson();        // Call function to update an existing person
           break;
       case "3":
        DeletePerson();    // Call function to delete a person
        break;
       case "4":
        GetPersonById();      // Call function to get a person by ID
        break;
        case "5":
        GetAllPersons();      // Call function to get all persons
        break;    

        case "6":
            Environment.Exit(0);  // Exit the application with success code 0
            break;
        default:
            Console.WriteLine("Invalid option");  // Handle invalid input
            break;
    }
}

// Function to add a new person to the database
void AddPerson()
{
    // Prompt user for person's name and read input
    Console.Write("Name: ");
    var name = Console.ReadLine() ?? "";  // Use empty string if input is null

    // Prompt user for person's age and validate input
    Console.Write("Age: ");
    int age;  // Variable to store the parsed age
    // Loop until user enters a valid integer for age
    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.Write("Invalid input. Please enter a valid Age: ");  // Error message for invalid input
    }

    // Prompt user for person's email and read input
    Console.Write("Email: ");
    var email = Console.ReadLine() ?? "";  // Use empty string if input is null

    // Create a new Person object with the user input
    var person = new Person
    {
        Name = name,    // Set the name from user input
        Age = age,      // Set the age from user input
        Email = email,  // Set the email from user input
    };

    // Add the person to the database through the service layer
    personService.AddPerson(person);
}

// Function to update an existing person in the database
void UpdatePerson()
{
    Console.WriteLine("===Update Person===");  // Display update header
    Console.Write("Enter the id of the person to update:");  // Prompt for person ID
    var id = int.Parse(Console.ReadLine());  // Parse the ID from user input
    Console.Write("New name:");  // Prompt for new name
    var name = Console.ReadLine();  // Read new name from user
    Console.Write("New age:");  // Prompt for new age
    var age = int.Parse(Console.ReadLine());  // Parse new age from user input
    Console.Write("New Email:");  // Prompt for new email
    var email = Console.ReadLine();  // Read new email from user

    // Create a new Person object with updated information
    var person = new ADO.Models.Person
    {
        Id = id,        // Set the ID to identify which person to update
        Name = name,    // Set the new name
        Age = age,      // Set the new age
        Email = email   // Set the new email
    };
    personService.UpdatePerson(person);  // Call service to update the person
    Console.WriteLine("Person updated sucessfully.");  // Display success message
}

// Function to delete a person from the database
void DeletePerson()
{
    Console.WriteLine("Delete person");  // Display delete header
    Console.Write("Enter the id of the person:");  // Prompt for person ID
    var id = int.Parse(Console.ReadLine());  // Parse the ID from user input
    personService.DeletePerson(id);  // Call service to delete the person
    Console.WriteLine("Person deleted sucessfully:");  // Display success message
}

// Function to get a specific person by their ID
void GetPersonById ()
{
    Console.WriteLine("Get Person by Id");  // Display get person header
    Console.Write("Enter the id of the person:");  // Prompt for person ID
    var id = int.Parse(Console.ReadLine());  // Parse the ID from user input
    
    var person = personService.GetPersonById(id);  // Get person from service
    
    if (person != null)  // Check if person was found
    {
        Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");  // Display person details
    }
    else  // If person was not found
    {
        Console.WriteLine("Person not found.");  // Display not found message
    }
}

// Function to get and display all persons from the database
void GetAllPersons()
{
    // Get all people from the service layer
    var people = personService.GetAllPersons();
    // Iterate through each person and display their details
    foreach (var person in people)  // Loop through each person in the list
    {
        // Format and display person information in a readable format
        Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
    }
}



