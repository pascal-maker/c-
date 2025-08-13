using System;
using System.Collections.Generic;
using Ct.Ai.Models; // import the namespace

class People
{
    static void Main(string[] args)
    {
        // Way 1: Normal constructor initialization
        Person p1 = new Person("Pascal", "Musabyimana", 24, "Gerard Willemotlaan 30, 9000 Gent, Belgium", 
                               "pascal-musa@hotmail.com", "0456180134");

        // Way 2: Object initializer (without custom constructor)
        Person p2 = new Person("John", "Doe", 30, "123 Main St, Apt 4B, 12345, Exampleville, Countryland", 
                               "john.doe@example.com", "(123) 456-7890");

        // Store in a list
        List<Person> people = new List<Person> { p1, p2 };

        // Iterate and display info
        foreach (var person in people)
        {
            person.Introduce();
        }
    }
}
