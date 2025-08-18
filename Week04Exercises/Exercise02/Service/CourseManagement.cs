// Import the Student and Course models to use in this service
using Students.Management.Library.Models;

// Define the namespace for service implementations
namespace Students.Management.Library.Service;

// Define the CourseManagement class to handle business logic for course and student operations
// This class acts as the main service layer for the course management system
// It manages the interaction between the user interface and the data layer
public class CourseManagement
{
    // Private fields to store lists of students and courses in memory
    // These lists are used for the current session and are initialized with sample data
    private List<Student> _students;
    private List<Course> _courses;

    // Constructor that initializes the CourseManagement service
    // This sets up the initial data and prepares the system for use
    public CourseManagement()
    {
        // Call the Init method to set up initial data
        Init();
    }

    // Region to group all public methods that can be called from outside the class
    #region Public

    // Main menu method that displays the user interface and handles user interactions
    // This is the entry point for the course management system
    public void Menu()
    {
        // Variable to store the user's menu choice
        int choice = 0;
        
        // Display the main title of the application
        Console.WriteLine("Course Management System");

        // Main menu loop that continues until the user chooses to exit (choice = 99)
        while (choice != 99)
        {
            // Display all available menu options
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Add Student to Course");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. List Courses");
            Console.WriteLine("6. List Students in Course");
            Console.WriteLine("7. Total course price student is enrolled in");
            Console.WriteLine("99. Exit");
            
            // Read the user's choice and convert it to an integer
            choice = Convert.ToInt32(Console.ReadLine());
            
            // Call the ChooseAction method to handle the user's choice
            ChooseAction(choice);
        }
    }

    // End of public region
    #endregion

    // Region to group all private methods that are used internally by the class
    #region Private

    // Method to handle the user's menu choice and execute the corresponding action
    // This method uses a switch statement to route to the appropriate functionality
    private void ChooseAction(int choice)
    {
        // Switch statement to handle different menu choices
        switch (choice)
        {
            case 1:
                // Call the method to add a new student
                AddStudent();
                break;
            case 2:
                // Call the method to add a new course
                AddCourse();
                break;
            case 3:
                // Call the method to enroll a student in a course
                AddStudentToCourse();
                break;
            case 4:
                // Call the method to display all students
                ListStudents();
                break;
            case 5:
                // Call the method to display all courses
                ListCourses();
                break;
            case 6:
                // Call the method to display students in a specific course
                ListStudentsInCourse();
                break;
            case 7:
                // Call the method to calculate total course price for a student
                TotalPriceStudentIsEnrolledIn();
                break;
            case 99:
                // Display exit message and terminate the application
                Console.WriteLine("Exiting");
                Environment.Exit(0);
                break;
            default:
                // Handle invalid menu choices (no action needed)
                break;
        }
    }

    // Method to calculate and display the total price of all courses a student is enrolled in
    private void TotalPriceStudentIsEnrolledIn()
    {
        // Display all students so the user can choose one
        Console.WriteLine("Choose a student from the list by it's Id");
        _students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        
        // Read the student ID from user input and convert to integer
        int studentId = Convert.ToInt32(Console.ReadLine());
        
        // Find the student with the specified ID
        Student student = _students.Where(s => s.Id == studentId).FirstOrDefault();
        
        // Initialize total price variable
        decimal totalPrice = 0;
        
        // Calculate the sum of all course prices for the student
        student.Courses.ForEach(c => totalPrice += c.Price);
        
        // Display the total price to the user
        Console.WriteLine($"Total price of courses: €{totalPrice}");
    }

    // Method to display all students enrolled in a specific course
    private void ListStudentsInCourse()
    {
        // Display all courses so the user can choose one
        _courses.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: {c.Price}"));
        
        // Prompt user to enter course ID
        Console.WriteLine("Enter Course Id");
        
        // Read the course ID from user input and convert to integer
        int courseId = Convert.ToInt32(Console.ReadLine());
        
        // Find the course with the specified ID
        Course course = _courses.Where(c => c.Id == courseId).FirstOrDefault();
        
        // Display all students enrolled in the selected course
        course.Students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
    }

    // Method to display all courses in the system
    private void ListCourses()
    {
        // Loop through all courses and display their information
        foreach (Course course in _courses)
        {
            // Display course ID, name, and price with proper formatting
            Console.WriteLine($"Id: {course.Id}, Name: {course.Name}, Price: €{course.Price}");
        }
    }

    // Method to display all students in the system
    private void ListStudents()
    {
        // Loop through all students and display their information
        foreach (Student student in _students)
        {
            // Display student ID, name, and email
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Email: {student.Email}");
        }
    }

    // Method to enroll a student in a course
    private void AddStudentToCourse()
    {
        // Display all students so the user can choose one
        Console.WriteLine("Choose a student from the list by it's Id");
        _students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        
        // Read the student ID from user input and convert to integer
        int studentId = Convert.ToInt32(Console.ReadLine());

        // Display all courses so the user can choose one
        Console.WriteLine("Choose a course from the list by it's Id");
        _courses.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: €{c.Price}"));
        
        // Read the course ID from user input and convert to integer
        int courseId = Convert.ToInt32(Console.ReadLine());

        // Find the student and course objects using their IDs
        Student student = _students.Where(s => s.Id == studentId).FirstOrDefault();
        Course course = _courses.Where(c => c.Id == courseId).FirstOrDefault();
        
        // Add the course to the student's course list
        student.Courses.Add(course);
        
        // Add the student to the course's student list
        course.Students.Add(student);
        
        // Display confirmation message
        Console.WriteLine("Student added to course");
    }

    // Method to add a new course to the system
    private void AddCourse()
    {
        // Prompt user to enter course name
        Console.WriteLine("Enter Course Name");
        string name = Console.ReadLine();
        
        // Prompt user to enter course price
        Console.WriteLine("Enter Course Price");
        string strPrice = Console.ReadLine();
        
        // Convert the price string to decimal
        decimal Price = Convert.ToDecimal(strPrice);
        
        // Create a new course object with auto-generated ID
        Course course = new Course() { Id = _courses.Count + 1, Name = name, Price = Price };
        
        // Add the new course to the courses list
        _courses.Add(course);
    }

    // Method to add a new student to the system
    private void AddStudent()
    {
        // Prompt user to enter student name
        Console.WriteLine("Enter Student Name");
        string name = Console.ReadLine();
        
        // Prompt user to enter student email
        Console.WriteLine("Enter Student Email");
        string email = Console.ReadLine();
        
        // Create a new student object with auto-generated ID and empty course list
        Student student = new Student() { Id = _students.Count + 1, Name = name, Email = email, Courses = new List<Course>() };
        
        // Add the new student to the students list
        _students.Add(student);
    }

    // Method to initialize the system with sample data
    // This method sets up the initial students and courses for demonstration purposes
    private void Init()
    {
        // Initialize the students list with sample student data
        _students = new List<Student>(){
            // Create first sample student with ID 1
            new Student(){
                Id = 1, 
                Name = "John", 
                Email = "john@doe.com", 
                Class = "A1", 
                BirthDate = new DateOnly(2000,1,1), 
                Courses = new List<Course>()
            },
            // Create second sample student with ID 2
            new Student(){
                Id = 2, 
                Name = "Jane", 
                Email = "jane@doe.com", 
                Class = "B1", 
                BirthDate = new DateOnly(2000,5,4),  
                Courses = new List<Course>()
            },
        };

        // Initialize the courses list with sample course data
        _courses = new List<Course>(){
            // Create sample courses with different IDs, names, and prices
            new Course(){Id = 1, Name = "C#", Price = 350M, Students = new List<Student>()},
            new Course(){Id = 2, Name = "Java", Price = 350M, Students = new List<Student>()},
            new Course(){Id = 3, Name = "Python", Price = 350M, Students = new List<Student>()},
            new Course(){Id = 4, Name = "JavaScript", Price = 350M, Students = new List<Student>()},
            new Course(){Id = 5, Name = "C++", Price = 350M, Students = new List<Student>()},
            new Course(){Id = 6, Name = "PHP", Price = 350M, Students = new List<Student>()},
            new Course(){Id = 7, Name = "Ruby", Price = 150M, Students = new List<Student>()},
            new Course(){Id = 8, Name = "Swift", Price = 250M, Students = new List<Student>()},
        };

        // Set up some initial enrollments for demonstration
        // Enroll the first student (John) in the first three courses
        _students[0].Courses.Add(_courses[0]);  // John enrolled in C#
        _students[0].Courses.Add(_courses[1]);  // John enrolled in Java
        _students[0].Courses.Add(_courses[2]);  // John enrolled in Python
        
        // Also add John to the students list of each course
        _courses[0].Students.Add(_students[0]);  // C# has John as student
        _courses[1].Students.Add(_students[0]);  // Java has John as student
        _courses[2].Students.Add(_students[0]);  // Python has John as student
    }

    // End of private region
    #endregion
}