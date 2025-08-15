// Import necessary namespaces for reflection and models
using System.Reflection.Metadata.Ecma335;
using Students.Management.Library.Models;

// Define the namespace for repository implementations
namespace Students.Management.Library.Repositories;

// Implement the ICourseRepository interface
// This class handles all data access operations for courses using CSV files
// The repository pattern separates data access logic from business logic
public class CourseRepository : ICourseRepository
{
    // Define the path to the CSV file as a constant
    // This file stores all course data in comma-separated format
    private const string csvFile = "data/courses.csv";

    // Implementation of GetCourses method
    // This method reads all courses from the CSV file and converts them to Course objects
    public List<Course> GetCourses()
    {
        // Create a new list to store course objects
        List<Course> courses = new List<Course>();

        // Read all lines from the CSV file into an array
        // Each line represents one course record
        string[] lines = File.ReadAllLines(csvFile);

        // Loop through all lines starting from index 1 (skip the header row)
        // Index 0 contains column names: "Id,Name,Price"
        for (int i = 1; i < lines.Length; i++)
        {
            // Get the current line
            string line = lines[i];

            // Split the line by comma to separate the different fields
            // This creates an array where each element is one field
            string[] entries = line.Split(',');

            // Check if we have at least 3 fields (Id, Name, Price)
            if (entries.Length >= 3)
            {
                // Create a new Course object using object initializer syntax
                // This uses the default constructor and sets properties
                Course newCourse = new Course
                {
                    Id = int.Parse(entries[0].Trim()),           // Convert string to int for ID
                    Name = entries[1].Trim(),                   // Name is the second column
                    Price = decimal.Parse(entries[2].Trim())    // Price is the third column (use decimal for money)
                };

                // Add the created course to our list
                courses.Add(newCourse);
            }
        }

        // Return the complete list of courses
        return courses;
    }

    // Implementation of GetCourseById method
    // This method finds a course by its unique ID
    public Course? GetCourseById(int id)
    {
        // Get all courses from the CSV file
        var courses = GetCourses();
        
        // Use LINQ to find the first course with matching ID
        // FirstOrDefault returns the first match or null if no match is found
        return courses.FirstOrDefault(c => c.Id == id);
    }

    // Implementation of AddCourse method
    // This method adds a new course to the CSV file
    public void AddCourse(Course course)
    {
        // Check if the course parameter is null and throw an exception if it is
        // This prevents null reference exceptions later in the code
        ArgumentNullException.ThrowIfNull(course);

        // Read all existing courses from the CSV file
        var courses = GetCourses();

        // Add the new course to the list in memory
        courses.Add(course);

        // Create a new list to hold all lines that will be written to the CSV file
        var lines = new List<string>();

        // Add the header row first (column names)
        lines.Add("Id,Name,Price");

        // Loop through all courses (including the new one) and create CSV lines
        foreach (var cours in courses)
        {
            // Create a CSV line by joining all course properties with commas
            // Format: ID,Name,Price
            lines.Add($"{cours.Id},{cours.Name},{cours.Price}");
        }

        // Write all lines back to the CSV file, overwriting the existing content
        // This ensures the new course is permanently saved
        File.WriteAllLines(csvFile, lines);
    }

    // Implementation of UpdateCourse method
    // This method updates an existing course's information
    public void UpdateCourse(Course course)
    {
        // Check if the course parameter is null and throw an exception if it is
        ArgumentNullException.ThrowIfNull(course);
        
        // Get all existing courses from the CSV file
        var courses = GetCourses();
        
        // Find the existing course with the same ID
        var existingCourse = courses.FirstOrDefault(c => c.Id == course.Id);
        
        // If the course exists, update its information
        if (existingCourse != null)
        {
            // Remove the old course record
            courses.Remove(existingCourse);
            
            // Add the updated course record
            courses.Add(course);

            // Create a new list to hold all lines that will be written to the CSV file
            var lines = new List<string>();
            
            // Add the header row first (column names)
            lines.Add("Id,Name,Price");
            
            // Loop through all courses and create CSV lines
            foreach (var c in courses)
            {
                // Create a CSV line by joining all course properties with commas
                lines.Add($"{c.Id},{c.Name},{c.Price}");
            }
            
            // Write all lines back to the CSV file
            File.WriteAllLines(csvFile, lines);
        }
    }

    // Implementation of DeleteCourse method
    // This method removes a course from the CSV file
    public void DeleteCourse(int id)
    {
        // Get all existing courses from the CSV file
        var courses = GetCourses();
        
        // Find the course with the specified ID
        var course = courses.FirstOrDefault(c => c.Id == id);
        
        // If the course exists, remove it
        if (course != null)
        {
            // Remove the course from the list
            courses.Remove(course);

            // Create a new list to hold all lines that will be written to the CSV file
            var lines = new List<string>();

            // Add the header row first (column names)
            lines.Add("Id,Name,Price");
            
            // Loop through all remaining courses and create CSV lines
            foreach (var c in courses)
            {
                // Create a CSV line by joining all course properties with commas
                lines.Add($"{c.Id},{c.Name},{c.Price}");
            }
            
            // Write all lines back to the CSV file
            File.WriteAllLines(csvFile, lines);
        }
    }
}

    


