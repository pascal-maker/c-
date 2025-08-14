using System;
namespace Pascal.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }


        public Person(string name, string lastname, int age, string address, string email, string phone)
        {
            Name = name;
            LastName = lastname;
            Age = age;
            Address = address;
            Email = email;
            Phone = phone;
        }


        public void Introduce(string name, string lastname, int age, string address, string email, string phone)
        {
            Console.WriteLine($" Hello my name is  {name} and lastname {lastname} and age  {age} i live there my adress is {address}, my emailadress is {email} and phonenumber is {phone}");
        }







    }

    
    
    
    
    
}