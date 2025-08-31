// Import the Student and Course models to use in this service
using Students.Management.Library.Models;

// Define the namespace for service implementations
namespace Students.Management.Library.Service;

/// <summary>
/// CourseManagement - Service class voor het beheren van cursussen en studenten
/// Verantwoordelijk voor alle business logic van het cursus management systeem
/// Beheert de interactie tussen de user interface en de data layer
/// </summary>
public class CourseManagement
{
    // Private fields om lijsten van studenten en cursussen in memory op te slaan
    // Deze lijsten worden gebruikt voor de huidige sessie
    private List<Student> _students;
    private List<Course> _courses;

    /// <summary>
    /// Constructor die de CourseManagement service initialiseert
    /// Maakt lege lijsten aan voor studenten en cursussen
    /// </summary>
    public CourseManagement()
    {
        _students = new List<Student>();
        _courses = new List<Course>();
    }

    /// <summary>
    /// Hoofdmenu methode die de user interface toont en user interacties afhandelt
    /// Dit is het startpunt van het cursus management systeem
    /// Toont een menu met alle beschikbare opties en blijft draaien tot exit
    /// </summary>
    public void Menu()
    {
        int choice = 0;
        Console.WriteLine("Course Management System");

        // Hoofdmenu loop die blijft draaien tot de gebruiker kiest om te stoppen (choice = 99)
        while (choice != 99)
        {
            // Toon alle beschikbare menu opties
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Add Student to Course");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. List Courses");
            Console.WriteLine("6. List Students in Course");
            Console.WriteLine("7. Total course price student is enrolled in");
            Console.WriteLine("99. Exit");
            
            // Lees de keuze van de gebruiker en converteer naar integer
            choice = Convert.ToInt32(Console.ReadLine());
            ChooseAction(choice);
        }
    }

    /// <summary>
    /// Methode om de menu keuze van de gebruiker af te handelen
    /// Gebruikt een switch statement om naar de juiste functionaliteit te routeren
    /// </summary>
    /// <param name="choice">De menu keuze van de gebruiker (1-7 of 99)</param>
    private void ChooseAction(int choice)
    {
        switch (choice)
        {
            case 1:
                AddStudent();
                break;
            case 2:
                AddCourse();
                break;
            case 3:
                AddStudentToCourse();
                break;
            case 4:
                ListStudents();
                break;
            case 5:
                ListCourses();
                break;
            case 6:
                ListStudentsInCourse();
                break;
            case 7:
                TotalPriceStudentIsEnrolledIn();
                break;
            case 99:
                Console.WriteLine("Exiting");
                Environment.Exit(0);
                break;
        }
    }

    /// <summary>
    /// Berekent en toont de totale prijs van alle cursussen waar een student is ingeschreven
    /// Gebruikt LINQ Sum() methode voor efficiënte berekening
    /// </summary>
    private void TotalPriceStudentIsEnrolledIn()
    {
        // Toon alle studenten zodat de gebruiker er een kan kiezen
        Console.WriteLine("Choose a student from the list by its Id");
        _students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        
        // Lees de student ID van user input en converteer naar integer
        int studentId = Convert.ToInt32(Console.ReadLine());
        
        // Zoek de student met de opgegeven ID
        Student student = _students.FirstOrDefault(s => s.Id == studentId);
        
        // Controleer of de student bestaat en bereken totale prijs
        if (student != null)
        {
            // Gebruik LINQ Sum() om alle cursus prijzen op te tellen
            decimal totalPrice = student.Courses.Sum(c => c.Price);
            Console.WriteLine($"Total price of courses: €{totalPrice}");
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }

    /// <summary>
    /// Toont alle studenten die ingeschreven zijn in een specifieke cursus
    /// Zoekt eerst de cursus op basis van ID en toont dan alle ingeschreven studenten
    /// </summary>
    private void ListStudentsInCourse()
    {
        // Toon alle cursussen zodat de gebruiker er een kan kiezen
        _courses.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: {c.Price}"));
        Console.WriteLine("Enter Course Id");
        
        // Lees de cursus ID van user input en converteer naar integer
        int courseId = Convert.ToInt32(Console.ReadLine());
        
        // Zoek de cursus met de opgegeven ID
        Course course = _courses.FirstOrDefault(c => c.Id == courseId);
        
        // Controleer of de cursus bestaat en toon alle ingeschreven studenten
        if (course != null)
        {
            course.Students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        }
        else
        {
            Console.WriteLine("Course not found!");
        }
    }

    /// <summary>
    /// Toont alle cursussen in het systeem
    /// Loop door alle cursussen en toon hun informatie
    /// </summary>
    private void ListCourses()
    {
        foreach (Course course in _courses)
        {
            Console.WriteLine($"Id: {course.Id}, Name: {course.Name}, Price: €{course.Price}");
        }
    }

    /// <summary>
    /// Toont alle studenten in het systeem
    /// Loop door alle studenten en toon hun informatie
    /// </summary>
    private void ListStudents()
    {
        foreach (Student student in _students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Email: {student.Email}");
        }
    }

    /// <summary>
    /// Schrijft een student in voor een cursus
    /// Voegt de cursus toe aan de student's cursus lijst en vice versa
    /// Maakt een many-to-many relatie tussen student en cursus
    /// </summary>
    private void AddStudentToCourse()
    {
        // Toon alle studenten zodat de gebruiker er een kan kiezen
        Console.WriteLine("Choose a student from the list by its Id");
        _students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Email: {s.Email}"));
        
        // Lees de student ID van user input
        int studentId = Convert.ToInt32(Console.ReadLine());

        // Toon alle cursussen zodat de gebruiker er een kan kiezen
        Console.WriteLine("Choose a course from the list by its Id");
        _courses.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Price: €{c.Price}"));
        
        // Lees de cursus ID van user input
        int courseId = Convert.ToInt32(Console.ReadLine());

        // Zoek de student en cursus objecten op basis van hun IDs
        Student student = _students.FirstOrDefault(s => s.Id == studentId);
        Course course = _courses.FirstOrDefault(c => c.Id == courseId);
        
        // Controleer of beide bestaan en voeg de relatie toe
        if (student != null && course != null)
        {
            // Voeg de cursus toe aan de student's cursus lijst
            student.Courses.Add(course);
            
            // Voeg de student toe aan de cursus's student lijst
            course.Students.Add(student);
            
            Console.WriteLine("Student added to course!");
        }
        else
        {
            Console.WriteLine("Student or course not found!");
        }
    }

    /// <summary>
    /// Voegt een nieuwe cursus toe aan het systeem
    /// Vraagt gebruiker om naam en prijs, maakt een nieuw Course object
    /// Auto-generates een ID op basis van het aantal bestaande cursussen
    /// </summary>
    private void AddCourse()
    {
        // Vraag gebruiker om cursus naam
        Console.WriteLine("Enter Course Name:");
        string name = Console.ReadLine();
        
        // Vraag gebruiker om cursus prijs
        Console.WriteLine("Enter Course Price:");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        
        // Maak een nieuw Course object met object initializer syntax
        Course course = new Course() 
        { 
            Id = _courses.Count + 1,  // Auto-generate ID
            Name = name, 
            Price = price,
            Students = new List<Student>()  // Initialiseer lege student lijst
        };
        
        // Voeg de nieuwe cursus toe aan de cursussen lijst
        _courses.Add(course);
        Console.WriteLine("Course added successfully!");
    }

    /// <summary>
    /// Voegt een nieuwe student toe aan het systeem
    /// Vraagt gebruiker om naam en email, maakt een nieuw Student object
    /// Auto-generates een ID op basis van het aantal bestaande studenten
    /// </summary>
    private void AddStudent()
    {
        // Vraag gebruiker om student naam
        Console.WriteLine("Enter Student Name:");
        string name = Console.ReadLine();
        
        // Vraag gebruiker om student email
        Console.WriteLine("Enter Student Email:");
        string email = Console.ReadLine();
        
        // Maak een nieuw Student object met object initializer syntax
        Student student = new Student() 
        { 
            Id = _students.Count + 1,  // Auto-generate ID
            Name = name, 
            Email = email, 
            Courses = new List<Course>()  // Initialiseer lege cursus lijst
        };
        
        // Voeg de nieuwe student toe aan de studenten lijst
        _students.Add(student);
        Console.WriteLine("Student added successfully!");
    }
}