using System.Globalization;
using System.IO;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;


namespace Students.Management.Library.Repositories
{
    public class EnrollmentRepository
    {
        private readonly string _filePath = "data/studentcourses.csv";
        //create a course object from the parts
        public List<Enrollment> GetEnrollements()
        {
            var lines = File.ReadAllLines(_filePath);
            var enrollments = new List<Enrollment>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                enrollments.Add(new Enrollment
                {
                    StudentId = int.Parse(parts[0]),
                    CourseId = int.Parse(parts[1])



                });
            }
            return enrollments;

        }

        //this method is rwesponsible for adding new enrollments to your csv file;



        public void AddEnrollment(Enrollment enrollment)
        {
            using var writer = File.AppendText(_filePath);
            writer.WriteLine($"{enrollment.StudentId},{enrollment.CourseId}");
        }

        public List<Enrollment> GetAllEnrollments()
        {
         return GetEnrollements();
       }
       


    
   }
}

