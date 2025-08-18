// Import the Course model to use in this interface
using Students.Management.Library.Models;

// Define the namespace for repository interfaces
namespace Students.Management.Library.Repositories;

// Define the interface for course repository operations
// This interface defines the contract that any course repository must implement
// The repository pattern separates data access logic from business logic
public interface ICourseRepository
{
    // Method to retrieve all courses from the data source
    // Returns a list of all Course objects
    // This is typically used to display all courses in the system
    List<Course> GetCourses();

    // Method to add a new course to the data source
    // Takes a Course object as parameter
    // This method should validate the course data before saving
    void AddCourse(Course course);

    // Method to find a course by its unique ID
    // Returns the Course if found, null if not found
    // The ? makes the return type nullable (can return null)
    // This is useful for checking if a course exists before performing operations
    Course? GetCourseById(int id);

    // Method to update an existing course's information
    // Takes a Course object with updated information
    // This method should validate the updated data before saving
    void UpdateCourse(Course course);

    // Method to delete a course from the data source
    // Takes the course's ID as parameter
    // This method should handle any cleanup needed (like removing enrollments)
    void DeleteCourse(int id);
}
