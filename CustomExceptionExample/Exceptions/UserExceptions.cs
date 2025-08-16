namespace CustomExceptionExample.Exceptions;

// Custom exception for invalid user age
public class InvalidAgeException : Exception
{
    public int Age { get; }
    public int MinimumAge { get; }

    public InvalidAgeException(int age, int minimumAge = 18)
        : base($"Invalid age: {age}. Minimum required age is {minimumAge}.")
    {
        Age = age;
        MinimumAge = minimumAge;
    }

    public InvalidAgeException(string message, int age, int minimumAge)
        : base(message)
    {
        Age = age;
        MinimumAge = minimumAge;
    }
}

// Custom exception for duplicate email addresses
public class DuplicateEmailException : Exception
{
    public string Email { get; }

    public DuplicateEmailException(string email)
        : base($"Email address already exists: {email}")
    {
        Email = email;
    }

    public DuplicateEmailException(string message, string email)
        : base(message)
    {
        Email = email;
    }
}

// Custom exception for invalid email format
public class InvalidEmailFormatException : Exception
{
    public string Email { get; }

    public InvalidEmailFormatException(string email)
        : base($"Invalid email format: {email}")
    {
        Email = email;
    }

    public InvalidEmailFormatException(string message, string email)
        : base(message)
    {
        Email = email;
    }
}
