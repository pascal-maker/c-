// Define the namespace for all ADO models
namespace ADO.Models;

// Person class that represents a person entity in the database
public class Person
{
    // Unique identifier for the person (auto-incremented in database)
    public int Id { get; set; }
    
    // Name of the person (required field)
    public string Name { get; set; } 
    
    // Age of the person (required field)
    public int Age { get; set; }
    
    // Email address of the person (required field)
    public string Email { get; set; } 
}
