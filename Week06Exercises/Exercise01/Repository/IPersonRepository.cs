// Import the Person model from ADO.Models namespace
using ADO.Models;
// Import MySQL data client for database operations
using MySql.Data.MySqlClient;

// Define the namespace for all ADO repositories
namespace ADO.Repositories;

// Interface that defines the contract for Person data access operations
public interface IPersonRepository
{
    // Method to add a new person to the database
    void AddPerson(Person person);

    // Method to update an existing person in the database
    void UpdatePerson(Person person);

    // Method to delete a person from the database by their ID
    void DeletePerson(int Id);

    // Method to retrieve a person from the database by their ID
    public Person GetPersonById(int Id);

    // Method to retrieve all persons from the database
    List<Person> GetAllPersons();
}