// Import necessary namespaces for runtime services and models
using System.Runtime.CompilerServices;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;

// Define the namespace for repository implementations
namespace Students.Management.Library.Repositories
{
    // Implement the IEnrollmentRepository interface
    // This class handles all enrollment operations between students and courses
    // The enrollment repository manages the many-to-many relationship between students and courses
    public class EnrollmentRepository : IEnrollmentRepository
    {
        // Define the path to the CSV file as a constant
        // This file stores all enrollment data (student-course relationships) in comma-separated format
        private const string csvFile = "data/studentcourses.csv";

        // Private fields to store references to the student and course repositories
        // These are injected through the constructor (dependency injection)
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        // Constructor that takes repository dependencies as parameters
        // This is called dependency injection - the enrollment repository depends on student and course repositories
        public EnrollmentRepository(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            // Store the injected repositories in the private fields
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        // Implementation of EnrollStudentInCourse method
        // This method creates an enrollment relationship between a student and a course
        public void EnrollStudentInCourse(int studentId, int courseId)
        {
            // Get the student and course objects using their IDs
            var student = _studentRepository.GetStudentById(studentId);
            var course = _courseRepository.GetCourseById(courseId);

            // Check if both student and course exist before creating the enrollment
            if (student != null && course != null)
            {
                // Add the enrollment record to the CSV file
                // Format: StudentId,CourseId
                var line = $"{studentId},{courseId}";
                File.AppendAllText(csvFile, line + Environment.NewLine);

                // Update the in-memory lists to maintain consistency
                // Add the course to the student's course list
                student.Courses.Add(course);
                // Add the student to the course's student list
                course.Students.Add(student);
            }
        }

        // Implementation of GetCoursesForStudent method
        // This method retrieves all courses that a specific student is enrolled in
        public List<Course> GetCoursesForStudent(int studentId)
        {
            // Get the student object using the student ID
            var student = _studentRepository.GetStudentById(studentId);
            
            // Return the student's courses list, or an empty list if student is null
            // The null-coalescing operator (??) provides a default value if the left side is null
            return student?.Courses ?? new List<Course>();
        }

        // Implementation of GetStudentsInCourse method
        // This method retrieves all students enrolled in a specific course
        public List<Student> GetStudentsInCourse(int courseId)
        {
            // Get the course object using the course ID
            var course = _courseRepository.GetCourseById(courseId);
            
            // Return the course's students list, or an empty list if course is null
            // The null-coalescing operator (??) provides a default value if the left side is null
            return course?.Students ?? new List<Student>();
        }

        // Implementation of RemoveStudentFromCourse method
        // This method removes the enrollment relationship between a student and a course
        public void RemoveStudentFromCourse(int studentId, int courseId)
        {
            // Read all enrollment records from the CSV file
            var lines = File.ReadAllLines(csvFile);
            
            // Filter out the specific enrollment record to remove
            // Keep all lines except the one that matches both studentId and courseId
            var newLines = lines.Where(line =>
            {
                // Split each line to get the student and course IDs
                var parts = line.Split(',');
                // Return true to keep the line if it doesn't match the enrollment to remove
                return !(parts[0] == studentId.ToString() && parts[1] == courseId.ToString());
            }).ToArray();

            // Write the filtered lines back to the CSV file
            // This effectively removes the specified enrollment
            File.WriteAllLines(csvFile, newLines);
        }

        // Implementation of GetTotalPriceForStudent method
        // This method calculates the total cost of all courses a student is enrolled in
        public decimal GetTotalPriceForStudent(int studentId)
        {
            // Get the student object using the student ID
            var student = _studentRepository.GetStudentById(studentId);
            
            // Calculate the sum of all course prices for the student
            // If student is null, return 0 (no courses, no cost)
            // The null-coalescing operator (??) provides a default value if the left side is null
            return student?.Courses.Sum(c => c.Price) ?? 0m;
        }
    }
}