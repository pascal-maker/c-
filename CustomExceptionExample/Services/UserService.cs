using CustomExceptionExample.Exceptions;
using CustomExceptionExample.Models;

namespace CustomExceptionExample.Services;

// User service that demonstrates custom exceptions
public class UserService
{
    // Simulated database of users
    private readonly List<User> _users;
    private const int MinimumAge = 18;

    public UserService()
    {
        // Initialize with some sample users
        _users = new List<User>
        {
            new User("John Doe", "john@email.com", 25),
            new User("Jane Smith", "jane@email.com", 30),
            new User("Bob Wilson", "bob@email.com", 35)
        };
    }

    // Method that throws InvalidAgeException
    public void CreateUser(string name, string email, int age)
    {
        // Validate age
        if (age < MinimumAge)
        {
            throw new InvalidAgeException(age, MinimumAge);
        }

        // Validate email format (simple validation)
        if (!IsValidEmail(email))
        {
            throw new InvalidEmailFormatException(email);
        }

        // Check for duplicate email
        if (_users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
        {
            throw new DuplicateEmailException(email);
        }

        // Create and add user
        var newUser = new User(name, email, age);
        _users.Add(newUser);
        Console.WriteLine($"✅ Successfully created user: {name} ({email})");
    }

    // Helper method to validate email format
    private bool IsValidEmail(string email)
    {
        // Simple email validation - in real applications, use more robust validation
        return email.Contains("@") && email.Contains(".") && email.Length > 5;
    }

    // Method to get all users
    public List<User> GetAllUsers()
    {
        return _users.ToList();
    }
}
