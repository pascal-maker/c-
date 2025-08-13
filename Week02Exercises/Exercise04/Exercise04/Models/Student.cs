namespace Ct.Ai.Models

{

public class Student
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public string Classes { get; set; }
    public string BirthDate { get; set; }

        public Student(string name, string email, string classes, string birthdate)
        {
            Name = name;
            Email = email;
            Classes = classes;
            BirthDate = birthdate;



        }

    public override string ToString()
        {
            return $" {Name}, {Email},{Classes},{BirthDate}";
        }
}

}