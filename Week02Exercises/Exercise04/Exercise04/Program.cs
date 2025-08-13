using System;
using System.Collections.Generic;

namespace Ct.Ai.Models
{
    class CourseSystem
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }



    public class Menu
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private Dictionary<Student, List<Course>> enrollments = new Dictionary<Student, List<Course>>();

        public void Show()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Student management menu----");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Add Course");
                Console.WriteLine("3.Show Students");
                Console.WriteLine("4.Show Courses");
                Console.WriteLine("5.Enroll Student in Course");
                Console.WriteLine("6.Show Total Price for Student");
                Console.WriteLine("7.Exit");
                Console.Write("Enter choice:");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddCourse();
                        break;
                    case 3:
                        ShowStudents();
                        break;
                    case 4:
                        ShowCourses();
                        break;
                    case 5:
                        EnrollStudent();
                        break;
                    case 6:
                        ShowStudentTotalPrice();
                        break;
                    case 7:
                        running = false;
                         break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;






                }


            }
        }

        private void AddStudent()
        {
            Console.Write("Enter name:");
            string name = Console.ReadLine();

            Console.Write("Enter email:");
            string email = Console.ReadLine();

            Console.Write("Enter class:");
            string classes = Console.ReadLine();

            Console.Write("Enter BirthDate:");
            string birthdate = Console.ReadLine();


            var student = new Student(name, email, classes, birthdate);
            students.Add(student);
            enrollments[student] = new List<Course>();
            Console.WriteLine("Student added!");


        }

        private void AddCourse()
        {
            Console.Write("Enter a Course ID:");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter course name:");
            string coursename = Console.ReadLine();

            Console.Write("Enter course price:");
            double courseprice = double.Parse(Console.ReadLine());

            var course = new Course(id, coursename, courseprice);
            courses.Add(course);
            Console.WriteLine("courses added!");


        }

        private void ShowStudents()
        {
            Console.WriteLine("\n--- Students--- ");
            int i = 1;
            foreach (var s in students)
                Console.WriteLine($"{i++} .{s}");

        }

        private void ShowCourses()
        {
            Console.WriteLine("\n--- Courses--- ");
            int i = 1;
            foreach (var c in courses)
                Console.WriteLine($"{i++} .{c}");

        }

        private void EnrollStudent()
        {
            if (students.Count == 0 || courses.Count == 0)
            {
                Console.WriteLine("Add at least one student and one course first.");
                return;
            }

            Console.WriteLine("Choose a student:");
            for (int i = 0; i < students.Count; i++)
                Console.WriteLine($"{i + 1}. {students[i].Name}");
            int studentIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Choose a course:");
            for (int i = 0; i < courses.Count; i++)
                Console.WriteLine($"{i + 1}. {courses[i].CourseName}");
            int courseIndex = int.Parse(Console.ReadLine()) - 1;


            var student = students[studentIndex];
            var course = courses[courseIndex];

            enrollments[student].Add(course);
            Console.WriteLine($"Enrolled {student.Name} in {course.CourseName}");


        }

        private void ShowStudentTotalPrice()
        {
            Console.WriteLine("Choose a student:");
            for (int i = 0; i < students.Count; i++)
                Console.WriteLine($"{i + 1} . {students[i].Name}");
            int studentIndex = int.Parse(Console.ReadLine()) - 1;


            var student = students[studentIndex];
            var studentCourses = enrollments[student];
            double total = 0;

            Console.WriteLine($"\n Courses for {student.Name}:");
            foreach (var course in studentCourses)
            {
                Console.WriteLine($"{course.CourseName}:  €{course.CoursePrice:F2} ");
                total += course.CoursePrice;

            }

            Console.WriteLine($" Total price: €{total:F2}");
        }
        

        
        


    }
}
