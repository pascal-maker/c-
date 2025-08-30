using System;

namespace menu.Models
{
    public class Student
    {
        public string Name {get;set;}

        public string Email {get;set;}

        public string Klas {get;set;}

        public DateTime BirthDate {get;set;}

        public Student(string name,string email,string klas,DateTime birthdate)
        {
            Name = name;
            Email = email;
            Klas = klas;
            BirthDate = birthdate;
        }
    }
}