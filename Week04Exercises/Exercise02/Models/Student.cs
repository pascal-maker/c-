// Define the namespace for student models
namespace Students.Management.Library.Models;

// Define the Student class to represent a student entity
// This class contains all the properties that describe a student
public class Student
{
    // Property to store the unique identifier of the student
    // This is the primary key for identifying each student
    public int Id { get; set; }

    // Property to store the full name of the student
    // This is the student's first and last name
    public string Name { get; set; }

    // Property to store the student's email address
    // Used for communication and identification
    public string Email { get; set; }

    // Property to store the class/grade level of the student
    // Examples: "A1", "B1", "Class A", etc.
    public string Class { get; set; }

    // Property to store the student's birth date
    // Using DateOnly type for date-only information (no time component)
    public DateOnly BirthDate { get; set; }

    // Property to store the list of courses the student is enrolled in
    // This creates a many-to-many relationship with courses
    // Each student can be enrolled in multiple courses
    public List<Course> Courses { get; set; }
}
