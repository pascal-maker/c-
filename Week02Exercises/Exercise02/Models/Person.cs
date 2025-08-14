using System;
namespace Pascale.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public  List<Addresse>  Addresses{ get; set; }
        public List<string> EmailAdresses { get; set; }

        public List<string> PhoneNumbers { get; set; }


        public Person(string name, string lastname, int age, List<Addresse> addresses, List<string > emailadresses, List<string > phonenumbers)
        {
            Name = name;
            LastName = lastname;
            Age = age;
            Addresses = addresses;
            EmailAdresses = emailadresses;
            PhoneNumbers = phonenumbers;
        }


       public void Introduce()
{
    string addr = string.Join(" | ", Addresses ?? new());
    string emails = string.Join(", ", EmailAdresses ?? new());
    string phones = string.Join(", ", PhoneNumbers ?? new());
    // Addresses ?? new()
// If Addresses is not null, use it; otherwise use a new empty list.
// This avoids a NullReferenceException.

// string.Join(" | ", ...)
// Takes all items in the list and joins them into a single string separated by " | ".
// If Addresses contains two Addresse objects, and since your Addresse class has a ToString() method,
// it might produce: "gerard willemotlaan,24,9030 | youranus,69,666"


    Console.WriteLine(
        $"Hello, my name is {Name} and lastname {LastName} and age {Age}. " +
        $"I live here; my address(es): {addr}. My email address(es): {emails}. " +
        $"My phone number(s): {phones}."
    );
    Console.WriteLine();
}


    }

}