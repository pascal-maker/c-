using System.Globalization;
using System.IO;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;

namespace Students.Management.Library.Repositories
{
    public class StudentRepository
    {
        private static readonly CultureInfo EnUs = CultureInfo.InvariantCulture;

        private readonly string _filePath = "data/students.csv";
        // Create a Smartphone object from the parts
        public List<Student> GetStudents()
        {
            var lines = File.ReadAllLines(_filePath);
            var students = new List<Student>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                students.Add(new Student
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Email = parts[2],
                    Class = parts[3],
                    BirthDate = DateOnly.FromDateTime(
                    DateTime.ParseExact(parts[4].Trim(), "M/d/yyyy", EnUs))

                });
            }

            return students;
        }

        //This method is responsible for adding one new student to your CSV file.

        public void AddStudent(Student student)

        {
            using var writer = File.AppendText(_filePath);
            writer.WriteLine($"{student.Id},{student.Name},{student.Email},{student.Class},{student.BirthDate.ToDateTime(TimeOnly.MinValue).ToString("M/d/yyyy", EnUs)}");
        }
        

       public List<Student> GetAllStudents()
       {
       return GetStudents();
       }

       public Student GetStudentsById(int id)
       {
        return GetStudents().FirstOrDefault(s => s.Id == id);
      }
        
        //this methpd looks throught the list foe all studens and returns one with a matching id for null ifnone is found GETsartPhones loads allphones rom csv firstorDefaults.Id--id) finds the first march or returns null the ? in smarthone means its okay if nothing is found

    }
}