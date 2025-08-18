// Import the Student model to use in this interface
using Students.Management.Library.Models;

// Define the namespace for repository interfaces
namespace Students.Management.Library.Repositories;

// Define the interface for student repository operations
// This interface defines the contract that any student repository must implement
// The repository pattern separates data access logic from business logic
public interface IStudentRepository
{
    // Method to retrieve all students from the data source
    // Returns a list of all Student objects
    // This is typically used to display all students in the system
    List<Student> GetStudents();

    // Method to add a new student to the data source
    // Takes a Student object as parameter
    // This method should validate the student data before saving
    void AddStudent(Student student);

    // Method to find a student by its unique ID
    // Returns the Student if found, null if not found
    // The ? makes the return type nullable (can return null)
    // This is useful for checking if a student exists before performing operations
    Student? GetStudentById(int id);

    // Method to update an existing student's information
    // Takes a Student object with updated information
    // This method should validate the updated data before saving
    void UpdateStudent(Student student);

    // Method to delete a student from the data source
    // Takes the student's ID as parameter
    // This method should handle any cleanup needed (like removing enrollments)
    void DeleteStudent(int id);
}
