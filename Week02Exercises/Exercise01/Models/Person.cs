using System;

namespace Pascal.Models
{
    public class Person
    {
        // Eigenschappen (properties) van een persoon
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Constructor maakt een nieuwe instantie (object) van Person
        // => Zonder "new Person(...)" bestaat er nog geen persoon in het geheugen
        public Person(string name, string lastname, int age, string address, string email, string phone)
        {
            Name = name;
            LastName = lastname;
            Age = age;
            Address = address;
            Email = email;
            Phone = phone;
        }

        // Introduce hoeft GEEN parameters meer te hebben,
        // want alle info zit al in het object (via de constructor).
        // Je roept dus gewoon "p1.Introduce();" aan.
        public void Introduce()
        {
            Console.WriteLine(
                $"Hallo, mijn naam is {Name} {LastName}, ik ben {Age} jaar oud. " +
                $"Adres: {Address}, Email: {Email}, Telefoon: {Phone}"
            );
        }
    }
}
