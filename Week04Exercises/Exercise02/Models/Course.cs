// Define the namespace for course models
namespace Students.Management.Library.Models;

// Define the Course class to represent a course entity
// This class contains all the properties that describe a course
public class Course
{
    // Property to store the unique identifier of the course
    // This is the primary key for identifying each course
    public int Id { get; set; }

    // Property to store the name/title of the course
    // Examples: "C# Basics", "Java Programming", "Python for Beginners"
    public string Name { get; set; }

    // Property to store the price of the course
    // Using decimal type for precise monetary values
    // Examples: 49.99, 350.00, 129.99
    public decimal Price { get; set; }

    // Property to store the list of students enrolled in this course
    // This creates a many-to-many relationship with students
    // Each course can have multiple students enrolled
    public List<Student> Students { get; set; }
}