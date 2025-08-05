public class Person
{
    private string name;
    private int age;
    private string city;

    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public Person(string name, int age, string city)
    {
        this.name = name;
        this.age = age;
        this.city = city;
    }

    public string City
    {
        get
        {
            return city;
        }
    }

    public string Zipcode
    {
        set
        {

        }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
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

    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }


    public override string ToString()
    {
        return $"{Name}-{Age}";
    }
    
}
