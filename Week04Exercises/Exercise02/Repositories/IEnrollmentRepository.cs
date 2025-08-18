// Import the Student and Course models to use in this interface
using Students.Management.Library.Models;

// Define the namespace for repository interfaces
namespace Students.Management.Library.Repositories;

// Define the interface for enrollment repository operations
// This interface defines the contract for managing student-course enrollments
// The enrollment repository handles the many-to-many relationship between students and courses
public interface IEnrollmentRepository
{
    // Method to enroll a student in a course
    // Takes the student ID and course ID as parameters
    // This creates the relationship between a student and a course
    void EnrollStudentInCourse(int studentId, int courseId);

    // Method to get all courses that a student is enrolled in
    // Takes the student ID as parameter
    // Returns a list of courses the student is taking
    List<Course> GetCoursesForStudent(int studentId);

    // Method to get all students enrolled in a specific course
    // Takes the course ID as parameter
    // Returns a list of students taking the course
    List<Student> GetStudentsInCourse(int courseId);

    // Method to remove a student from a course (unenroll)
    // Takes the student ID and course ID as parameters
    // This removes the relationship between a student and a course
    void RemoveStudentFromCourse(int studentId, int courseId);

    // Method to calculate the total price of all courses a student is enrolled in
    // Takes the student ID as parameter
    // Returns the sum of all course prices for the student
    decimal GetTotalPriceForStudent(int studentId);
}