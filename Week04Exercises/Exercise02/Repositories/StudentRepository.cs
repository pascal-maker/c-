// Import necessary namespaces for reflection, runtime services, globalization, and models
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Globalization;
using Students.Management.Library.Models;

// Define the namespace for repository implementations
namespace Students.Management.Library.Repositories;

// Implement the IStudentRepository interface
// This class handles all data access operations for students using CSV files
// The repository pattern separates data access logic from business logic
public class StudentRepository : IStudentRepository
{
    // Define the path to the CSV file as a constant
    // This file stores all student data in comma-separated format
    private const string csvFile = "data/students.csv";

    // Implementation of GetStudents method
    // This method reads all students from the CSV file and converts them to Student objects
    public List<Student> GetStudents()
    {
        // Create a new list to store student objects
        List<Student> students = new List<Student>();

        // Read all lines from the CSV file into an array
        // Each line represents one student record
        string[] lines = File.ReadAllLines(csvFile);

        // Loop through all lines starting from index 1 (skip the header row)
        // Index 0 contains column names: "Id,Name,Email,Class,BirthDate"
        for (int i = 1; i < lines.Length; i++)
        {
            // Get the current line
            string line = lines[i];

            // Split the line by comma to separate the different fields
            // This creates an array where each element is one field
            string[] entries = line.Split(',');

            // Check if we have at least 5 fields (Id, Name, Email, Class, BirthDate)
            if (entries.Length >= 5)
            {
                // Create a new Student object using object initializer syntax
                // This uses the default constructor and sets properties
                Student newStudent = new Student
                {
                    Id = int.Parse(entries[0].Trim()),           // Convert string to int for ID
                    Name = entries[1].Trim(),                   // Name is the second column
                    Email = entries[2].Trim(),                  // Email is the third column
                    Class = entries[3].Trim(),                  // Class is the fourth column
                    BirthDate = DateOnly.FromDateTime(          // BirthDate is the fifth column
                    DateTime.ParseExact(entries[4].Trim(), "M/d/yyyy", CultureInfo.InvariantCulture))
                };

                // Add the created student to our list
                students.Add(newStudent);
            }
        }

        // Return the complete list of students
        return students;
    }

    // Implementation of AddStudent method
    // This method adds a new student to the CSV file
    public void AddStudent(Student student)
    {
        // Check if the student parameter is null and throw an exception if it is
        // This prevents null reference exceptions later in the code
        ArgumentNullException.ThrowIfNull(student);

        // Read all existing students from the CSV file
        var students = GetStudents();

        // Add the new student to the list in memory
        students.Add(student);

        // Create a new list to hold all lines that will be written to the CSV file
        var lines = new List<string>();

        // Add the header row first (column names)
        lines.Add("Id,Name,Email,Class,BirthDate");

        // Loop through all students (including the new one) and create CSV lines
        foreach (var studente in students)
        {
            // Create a CSV line by joining all student properties with commas
            // Format: ID,Name,Email,Class,BirthDate
            lines.Add($"{studente.Id},{studente.Name},{studente.Email},{studente.Class},{studente.BirthDate:MM/dd/yyyy}");
        }

        // Write all lines back to the CSV file, overwriting the existing content
        // This ensures the new student is permanently saved
        File.WriteAllLines(csvFile, lines);
    }

    // Implementation of GetStudentById method
    // This method finds a student by its unique ID
    public Student? GetStudentById(int id)
    {
        // Get all students from the CSV file
        var students = GetStudents();
        
        // Use LINQ to find the first student with matching ID
        // FirstOrDefault returns the first match or null if no match is found
        return students.FirstOrDefault(s => s.Id == id);
    }

    // Implementation of UpdateStudent method
    // This method updates an existing student's information
    public void UpdateStudent(Student student)
    {
        // Check if the student parameter is null and throw an exception if it is
        ArgumentNullException.ThrowIfNull(student);
        
        // Get all existing students from the CSV file
        var students = GetStudents();
        
        // Find the existing student with the same ID
        var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
        
        // If the student exists, update their information
        if (existingStudent != null)
        {
            // Remove the old student record
            students.Remove(existingStudent);
            
            // Add the updated student record
            students.Add(student);

            // Create a new list to hold all lines that will be written to the CSV file
            var lines = new List<string>();
            
            // Add the header row first (column names)
            lines.Add("Id,Name,Email,Class,BirthDate");
            
            // Loop through all students and create CSV lines
            foreach (var s in students)
            {
                // Create a CSV line by joining all student properties with commas
                lines.Add($"{s.Id},{s.Name},{s.Email},{s.Class},{s.BirthDate:MM/dd/yyyy}");
            }
            
            // Write all lines back to the CSV file
            File.WriteAllLines(csvFile, lines);
        }
    }

    // Implementation of DeleteStudent method
    // This method removes a student from the CSV file
    public void DeleteStudent(int id)
    {
        // Get all existing students from the CSV file
        var students = GetStudents();
        
        // Find the student with the specified ID
        var student = students.FirstOrDefault(s => s.Id == id);
        
        // If the student exists, remove them
        if (student != null)
        {
            // Remove the student from the list
            students.Remove(student);

            // Create a new list to hold all lines that will be written to the CSV file
            var lines = new List<string>();

            // Add the header row first (column names)
            lines.Add("Id,Name,Email,Class,BirthDate");
            
            // Loop through all remaining students and create CSV lines
            foreach (var s in students)
            {
                // Create a CSV line by joining all student properties with commas
                lines.Add($"{s.Id},{s.Name},{s.Email},{s.Class},{s.BirthDate:MM/dd/yyyy}");
            }
            
            // Write all lines back to the CSV file
            File.WriteAllLines(csvFile, lines);
        }
    }
}