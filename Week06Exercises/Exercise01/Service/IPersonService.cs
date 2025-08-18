// Import the Person model from ADO.Models namespace
using ADO.Models;
// Import MySQL data client for database operations
using MySql.Data.MySqlClient;
// Import repository interfaces and implementations
using ADO.Repositories;

// Define the namespace for all ADO services
namespace ADO.Services;

// Interface that defines the contract for Person business logic operations
public interface IPersonService
{
    // Method to add a new person through the business logic layer
    void AddPerson(Person person);

    // Method to update an existing person through the business logic layer
    void UpdatePerson(Person person);

    // Method to delete a person through the business logic layer by their ID
    void DeletePerson(int Id);

    // Method to retrieve a person through the business logic layer by their ID
    public Person GetPersonById(int Id);

    // Method to retrieve all persons through the business logic layer
    List<Person> GetAllPersons();
}