// Define the namespace for enrollment models
namespace Students.Management.Library.Models;

// Define the Enrollment class to represent a student-course enrollment relationship
// This class acts as a junction/bridge table for the many-to-many relationship
// between students and courses
public class Enrollment
{
    // Property to store the ID of the student being enrolled
    // This is a foreign key reference to the Student table
    public int StudentId { get; set; }

    // Property to store the ID of the course the student is being enrolled in
    // This is a foreign key reference to the Course table
    public int CourseId { get; set; }
}

