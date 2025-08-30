using menu.Models;
using System;
using System.Collections.Generic;

public class Menu
{
    private List<Student> students = new List<Student>(); // lijst met alle studenten
    private List<Course> courses = new List<Course>();    // lijst met alle cursussen

    // Dictionary: elke student (Key) heeft een lijst met cursussen (Value)
    private Dictionary<Student, List<Course>> studentCourses = new Dictionary<Student, List<Course>>();

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("\nCourse Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Add Student to course");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. List Courses");
            Console.WriteLine("6. List Students in Courses");
            Console.WriteLine("7. Total course price student enrolled in");
            Console.WriteLine("99. Exit");
            Console.Write("Choose an option: ");

            var option = Console.ReadLine();
            Console.WriteLine();

            ParseOption(option);
        }
    }

    // Verwerk de keuze uit het menu
    private void ParseOption(string option)
    {
        switch(option)
        {
            case "1": AddStudent(); break;
            case "2": AddCourse(); break;
            case "3": AddStudentToCourse(); break;
            case "4": ListStudents(); break;
            case "5": ListCourse(); break;
            case "6": ListStudentInCourse(); break;   
            case "7": TotalCoursePriceStudent(); break;
            case "99":
                Console.WriteLine("Goodbye!");
                Environment.Exit(0); // programma stopt
                break;
            default:
                Console.WriteLine("Invalid option. Please choose 1-7!");
                break;
        }
    }

    // Student toevoegen
    private void AddStudent()
    {
        Console.Write("Enter a Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter an Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter a klas: ");
        string klas = Console.ReadLine();

        Console.Write("Enter Birth Date (DD/MM/YYYY or YYYY-MM-DD): ");
        string birthdateInput = Console.ReadLine() ?? "";

        // Parse de geboortedatum
        DateTime birthdate;
        if (!DateTime.TryParse(birthdateInput, out birthdate))
        {
            Console.WriteLine("Invalid date format! Please use DD/MM/YYYY or YYYY-MM-DD format.");
            return;
        }

        Student student = new Student(name, email, klas, birthdate);
        students.Add(student);
        Console.WriteLine("Student added.");
    }

    // Cursus toevoegen
    private void AddCourse()
    {
        Console.Write("Enter a Course ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID");
            return;
        }

        Console.Write("Enter a Course Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your price: ");
        if (!double.TryParse(Console.ReadLine(), out double price))
        {
            Console.WriteLine("Invalid price");
            return;
        }

        Course course = new Course(id, name, price);
        courses.Add(course);
        Console.WriteLine("Course added.");
    }

    // Student aan cursus koppelen
    private void AddStudentToCourse()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students yet. Add a student first.");
            return;
        }
        if (courses.Count == 0)
        {
            Console.WriteLine("No Courses yet. Add a course first.");
            return;
        }

        Console.WriteLine("Select student:");
        for (int i = 0; i < students.Count; i++)
            Console.WriteLine($"{i}. {students[i].Name}");

        // Index = positie in de lijst (0 = eerste, 1 = tweede, ...)
        // || betekent "OF": de input is ongeldig als:
        // - het geen getal is (!int.TryParse)
        // - OF de index kleiner is dan 0
        // - OF de index groter of gelijk is aan het aantal studenten
        if (!int.TryParse(Console.ReadLine(), out int sIndex)
            || sIndex < 0 || sIndex >= students.Count)
        {
            Console.WriteLine("Invalid student selection!");
            return;
        } 

        var selectedStudent = students[sIndex];

        Console.WriteLine("Select course:");
        for (int i = 0; i < courses.Count; i++)
            Console.WriteLine($"{i}. {courses[i].Name}");

        if (!int.TryParse(Console.ReadLine(), out int cIndex)
            || cIndex < 0 || cIndex >= courses.Count)
        {
            Console.WriteLine("Invalid course selection");
            return;
        }

        var selectedCourse = courses[cIndex];

        if (!studentCourses.ContainsKey(selectedStudent))
            studentCourses[selectedStudent] = new List<Course>();

        studentCourses[selectedStudent].Add(selectedCourse);
        Console.WriteLine("Course added to student");
    }

    // Studenten tonen
    private void ListStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students yet.");
            return;
        }

        for (int i = 0; i < students.Count; i++)
            Console.WriteLine($"{i}. {students[i].Name} - {students[i].Email}, {students[i].Klas}, {students[i].BirthDate}");

        Console.Write("Choose a student by number: ");

        if (int.TryParse(Console.ReadLine(), out int index)
            && index >= 0 && index < students.Count)
            Console.WriteLine($"You selected: {students[index].Name}");
        else
            Console.WriteLine("Invalid selection!");
    }

    // Cursussen tonen
    private void ListCourse()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses yet.");
            return;
        }

        for (int i = 0; i < courses.Count; i++)
            Console.WriteLine($"{i}. {courses[i].Name} {courses[i].Price} EUR");

        Console.Write("Choose a course by number: ");

        if (int.TryParse(Console.ReadLine(), out int index)
            && index >= 0 && index < courses.Count)
            Console.WriteLine($"You selected: {courses[index].ID} {courses[index].Name}");
        else
            Console.WriteLine("Invalid selection");
    }

    // Welke studenten zitten in een gekozen cursus
    private void ListStudentInCourse()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses yet");
            return;
        }

        Console.WriteLine("Choose a course:");
        for (int i = 0; i < courses.Count; i++)
            Console.WriteLine($"{i}. {courses[i].Name}");

        if (!int.TryParse(Console.ReadLine(), out int cIndex)
            || cIndex < 0 || cIndex >= courses.Count)
        {
            Console.WriteLine("Invalid course selection");
            return;
        }

        Course selectedCourse = courses[cIndex];
        Console.WriteLine($"Students enrolled in {selectedCourse.Name}:");

        bool any = false;

        foreach (var entry in studentCourses)
        {
            if (entry.Value.Contains(selectedCourse))
            {
                Console.WriteLine($" - {entry.Key.Name}");
                any = true;
            }
        }

        if (!any)
            Console.WriteLine("No students enrolled in this course!");
    }

    // Totale prijs berekenen van cursussen voor één student
    private void TotalCoursePriceStudent()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students yet.");
            return;
        }

        Console.WriteLine("Choose a student:");
        for (int i = 0; i < students.Count; i++)
            Console.WriteLine($"{i}. {students[i].Name}");

        if (int.TryParse(Console.ReadLine(), out int sIndex)
            && sIndex >= 0 && sIndex < students.Count)
        {
            Student selectedStudent = students[sIndex];

            if (studentCourses.TryGetValue(selectedStudent, out var enrolled)
                && enrolled.Count > 0)
            {
                double total = 0;
                foreach (Course c in enrolled)
                    total += c.Price;

                Console.WriteLine($"Total price for {selectedStudent.Name}'s courses: €{total:F2}");
            }
            else
            {
                Console.WriteLine("This student is not enrolled in any courses.");
            }
        }
        else
        {
            Console.WriteLine("Invalid student selection.");
        }
    }
}
