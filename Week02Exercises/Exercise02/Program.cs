
using System;
using Ct.Ai.Models;

class Persons
{
    static void Main(string[] args)
    {
        var addresses1 = new List<Address>
        {
            new Address
            {
                Street = "Gerard Willemotlaan",
                HouseNumber = "30",
                Zipcode = 9000,
                City = "Gent",
                Country = "Belgium",
            },

            new Address
            {
                Street = "Main Street",
                HouseNumber = "12",
                Zipcode = 1000,
                City = "Brussels",
                Country = "Belgium"

            }
        };

        var emails1 = new List<string> { "pascal-musa@hotmail.com", "pascalmusabyimana681@gmail.com" };
        var phones1 = new List<string> { "0456180134", "0488123456" };
        // alles via de constructor

        var m1 = new Multiple("pascal", "musabyimana", 23, addresses1, emails1, phones1);

        var addresses2 = new List<Address>
        {
            new Address
            {
                Street = "123 Main st",
                HouseNumber = "4b",
                Zipcode = 1000,
                City = "Brussel",
                Country = "CountryVille"
            },


        };

        var emails2 = new List<string> { "john.doe@example.com" };
        var phones2 = new List<string> { "(123)456-7890" };
        // alles via de constructor

        var m2 = new Multiple("John", "doe", 30, addresses2, emails2, phones2);

        var multiples = new List<Multiple> { m1, m2 };

        foreach (var person in multiples)
        {
            person.Introduce();
        }

        foreach (var person in multiples)
        {
            Console.WriteLine(person);
        }


    }
}