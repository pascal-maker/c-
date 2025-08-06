namespace Ct.Ai.Models

{

public class Course
{
    public int ID { get; set; }
    public string CourseName { get; set; }
    
    public double CoursePrice { get; set; }

     public Course(int id, string coursename, double courseprice)
        {
         ID= id;
         CourseName = coursename;
         CoursePrice = courseprice;
        
        }

    public override string ToString()
        {
            return $" {ID}, {CourseName},{CoursePrice}";
        }
}

}