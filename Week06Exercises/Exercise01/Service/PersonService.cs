// Import the Person model from ADO.Models namespace
using ADO.Models;
// Import MySQL data client for database operations
using MySql.Data.MySqlClient;
// Import repository interfaces and implementations
using ADO.Repositories;

// Define the namespace for all ADO services
namespace ADO.Services;

// Implementation of IPersonService that handles business logic for Person operations
public class PersonService : IPersonService
{
    // Private readonly field to store the person repository dependency
    private readonly IPersonRepository _personRepository;

    // Constructor that accepts repository dependencies (Dependency Injection pattern)
    public PersonService(IPersonRepository personRepository)
    {
        // Assign the injected repository to the private field
        _personRepository = personRepository;
    }

    // Method to add a new person by delegating to the person repository
    public void AddPerson(Person person)
    {
        // Call the person repository's AddPerson method
        _personRepository.AddPerson(person);
    }

    // Method to retrieve all people by delegating to the person repository
    public List<Person> GetAllPersons()
    {
        // Return the result from the person repository's GetAllPersons method
        return _personRepository.GetAllPersons();
    }

    // Method to update an existing person by delegating to the person repository
    public void UpdatePerson(Person person)
    {
        // Call the person repository's UpdatePerson method
        _personRepository.UpdatePerson(person);
    }

    // Method to delete a person by delegating to the person repository
    public void DeletePerson(int Id)
    {
        // Call the person repository's DeletePerson method
        _personRepository.DeletePerson(Id);
    }

    // Method to retrieve a person by their ID by delegating to the person repository
    public Person GetPersonById(int Id)
    {
        // Return the result from the person repository's GetPersonById method
        return _personRepository.GetPersonById(Id);  
    }
}