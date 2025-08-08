using System.Globalization;
using System.IO;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;


namespace Students.Management.Library.Repositories
{
    public class CourseRepository
    {
        private readonly string _filePath = "data/courses.csv";
        //create a course object from the parts
        public List<Course> GetCourses()
        {
            var lines = File.ReadAllLines(_filePath);
            var courses = new List<Course>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                courses.Add(new Course
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Price = decimal.Parse(parts[2], CultureInfo.InvariantCulture)



                });
            }
            return courses;

        }

        //this method is rwesponsible for adding new courses to your csv file;



        public void AddCourse(Course course)
        {
            using var writer = File.AppendText(_filePath);
            writer.WriteLine($"{course.Id},{course.Name},{course.Price}");
        }
       

       public List<Course> GetAllCourses()
       {
       return GetCourses();
       }

       public Course GetCourseById(int id)
       {
        return GetCourses().FirstOrDefault(c => c.Id == id);
      }

    
   }
}

