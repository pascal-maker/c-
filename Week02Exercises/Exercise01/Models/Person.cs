using System;
namespace Ct.Ai.Models
{
    public class Person
{
    private string name;
    private string lastname;
    private int age;

    private string address;
    private string email;
    private string phone;



    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, string lastname)
    {
        this.name = name;
        this.lastname = lastname;
    }

    public Person(string name, string lastname, int age)
    {

        this.name = name;
        this.lastname = lastname;
        this.age = age;
    }


    public Person(string name, string lastname, int age, string address)
    {

        this.name = name;
        this.lastname = lastname;
        this.age = age;
        this.address = address;
    }


    public Person(string name, string lastname, int age, string address, string email)
    {

        this.name = name;
        this.lastname = lastname;
        this.age = age;
        this.address = address;
        this.email = email;
    }

    public Person(string name, string lastname, int age, string address, string email, string phone)
    {

        this.name = name;
        this.lastname = lastname;
        this.age = age;
        this.address = address;
        this.email = email;
        this.phone = phone;
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public string LastName
    {
        get { return lastname; }
        set { lastname = value; }
    }


    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentOutOfRangeException("Age must be between 0 and 120");
            }
            age = value;
        }
    }


    public string Address
    {
        get { return address; }
        set { address = value; }
    }





    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }






    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {Name}  my lastname is {LastName} and I am {Age} years old. My adress is {Address} my Email is {Email} and phonenumber is {Phone}");
    }


    public override string ToString()
    {
        return $"{Name}-{LastName}--{Age}--{Address}--{Email}--{Phone}";
    }
}
}