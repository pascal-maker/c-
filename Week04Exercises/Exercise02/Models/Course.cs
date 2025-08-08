namespace Students.Management.Library.Models;

public class Course{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<Student> Students { get; set; }
}