// Import the Person model from ADO.Models namespace
using ADO.Models;
// Import MySQL data client for database operations
using MySql.Data.MySqlClient;

// Define the namespace for all ADO repositories
namespace ADO.Repositories;

// Implementation of IPersonRepository that handles database operations for Person entities
public class PersonRepository : IPersonRepository
{
    // Connection string for MySQL database (contains server, database, user, password, and SSL settings)
    private const string _connectionString = "server=localhost;database=Exercise01;user=root;password=9370;SslMode=None;AllowPublicKeyRetrieval=True;";

    // Method to add a new person to the database
    public void AddPerson(Person person)
    {
        // Create a new MySQL connection using the connection string
        MySqlConnection connection = new MySqlConnection(_connectionString);

        // Open the database connection
        connection.Open();
        // Create a new MySQL command with INSERT statement and connection
        MySqlCommand command = new MySqlCommand("INSERT INTO Persons (Name,Age,Email) VALUES (@Name,@Age,@Email)", connection);
        // Add parameter for Name with the person's name value
        command.Parameters.AddWithValue("Name", person.Name);
        // Add parameter for Age with the person's age value
        command.Parameters.AddWithValue("Age", person.Age);
        // Add parameter for Email with the person's email value
        command.Parameters.AddWithValue("Email", person.Email);

        // Execute the INSERT command (doesn't return any data)
        command.ExecuteNonQuery();

        // Close the database connection to free up resources
        connection.Close();
    }

    // Method to retrieve all persons from the database
    public List<Person> GetAllPersons()
    {
        // Create a new list to store all persons
        List<Person> people = new List<Person>();
        {
            // Create a new MySQL connection using the connection string
            MySqlConnection connection = new MySqlConnection(_connectionString);

            // Open the database connection
            connection.Open();

            // Create a new MySQL command with SELECT statement and connection
            MySqlCommand command = new MySqlCommand("SELECT * FROM Persons", connection);

            // Execute the SELECT command and get a data reader
            MySqlDataReader reader = command.ExecuteReader();
            // Loop through each row in the result set
            while (reader.Read())
            {
                // Add a new Person object to the list with data from current row
                people.Add(new Person
                {
                    Id = reader.GetInt32("Id"),        // Get the Id column as integer
                    Name = reader.GetString("Name"),   // Get the Name column as string
                    Age = reader.GetInt32("Age"),      // Get the Age column as integer
                    Email = reader.GetString("Email")  // Get the Email column as string
                });
            }

            // Close the database connection to free up resources
            connection.Close();
        }
        // Return the list of all persons
        return people;
    }

    // Method to update an existing person in the database
    public void UpdatePerson(Person person)
    {
        // Create a new MySQL connection using the connection string
        MySqlConnection connection = new MySqlConnection(_connectionString);

        // Open the database connection
        connection.Open();
        // Create a new MySQL command with UPDATE statement and connection
        MySqlCommand command = new MySqlCommand("UPDATE Persons SET  Name= @Name, Age = @Age, Email = @Email  WHERE Id = @Id",connection);
        // Add parameter for Id with the person's ID value
        command.Parameters.AddWithValue("Id", person.Id);
        // Add parameter for Name with the person's name value
        command.Parameters.AddWithValue("Name", person.Name);
        // Add parameter for Age with the person's age value
        command.Parameters.AddWithValue("Age", person.Age);
        // Add parameter for Email with the person's email value
        command.Parameters.AddWithValue("Email", person.Email);

        // Execute the UPDATE command (doesn't return any data)
        command.ExecuteNonQuery();

        // Close the database connection to free up resources
        connection.Close();
    }

    // Method to delete a person from the database by their ID
    public void DeletePerson(int Id)
    {
        // Create a new MySQL connection using the connection string
        MySqlConnection connection = new MySqlConnection(_connectionString);

        // Open the database connection
        connection.Open();
        // Create a new MySQL command with DELETE statement and connection
        MySqlCommand command = new MySqlCommand("DELETE FROM  Persons WHERE Id = @Id",connection);
        // Add parameter for Id with the provided ID value
        command.Parameters.AddWithValue("Id", Id);

        // Execute the DELETE command (doesn't return any data)
        command.ExecuteNonQuery();

        // Close the database connection to free up resources
        connection.Close();
    }

    // Method to retrieve a person from the database by their ID
    public Person GetPersonById(int Id)
    {
        // Create a new MySQL connection using the connection string
        MySqlConnection connection = new MySqlConnection(_connectionString);

        // Open the database connection
        connection.Open();
        // Create a new MySQL command with SELECT statement and connection
        MySqlCommand command = new MySqlCommand("SELECT  * FROM  Persons WHERE Id = @Id",connection);
        // Add parameter for Id with the provided ID value
        command.Parameters.AddWithValue("Id", Id);
        // Execute the SELECT command and get a data reader
        MySqlDataReader reader = command.ExecuteReader();
        // Check if there is a row to read (person found)
        if (reader.Read())
        { 
            // Return a new Person object with data from the row
            return new Person
            {
                Id = reader.GetInt32("Id"),        // Get the Id column as integer
                Name = reader.GetString("Name"),   // Get the Name column as string
                Age = reader.GetInt32("Age"),      // Get the Age column as integer
                Email = reader.GetString("Email")  // Get the Email column as string
            };
        }

        // Close the database connection to free up resources
        connection.Close();
        // Return null if no person was found with the given ID
        return null;
    }
}