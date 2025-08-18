namespace CustomExceptionExample.Models;

// Simple user model
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public User(string name, string email, int age)
    {
        Name = name;
        Email = email;
        Age = age;
    }
}
