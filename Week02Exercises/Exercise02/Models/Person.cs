using System;
using System.Collections.Generic;

namespace Pascale.Models
{
    public class Person
    {
        // Eigenschappen van een persoon
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        // Elke persoon kan meerdere adressen, e-mails en telefoonnummers hebben
        public List<Addresse> Addresses { get; set; }
        public List<string> EmailAddresses { get; set; }
        public List<string> PhoneNumbers { get; set; }

        // Constructor → maakt een nieuw persoon aan en vult alle gegevens in
        public Person(string name, string lastname, int age, List<Addresse> addresses, List<string> emailaddresses, List<string> phonenumbers)
        {
            Name = name;
            LastName = lastname;
            Age = age;
            Addresses = addresses;
            EmailAddresses = emailaddresses;
            PhoneNumbers = phonenumbers;
        }

        // ToString → zorgt ervoor dat Console.WriteLine(person) iets nuttigs toont
        public override string ToString()
        {
            return $"Person: {Name} {LastName}, Age: {Age}";
        }

        // Introduce → laat de persoon zichzelf voorstellen
        public void Introduce()
        {
            // string.Join → maakt van een lijst (List) één string met scheidingstekens ertussen
            string addressesText = string.Join(" | ", Addresses);     // meerdere adressen gescheiden door |
            string emailsText = string.Join(", ", EmailAddresses);    // meerdere e-mails gescheiden door ,
            string phonesText = string.Join(", ", PhoneNumbers);      // meerdere telefoons gescheiden door ,

            // Interpolatie → alle gegevens netjes in één zin
            Console.WriteLine(
                $"Hallo, mijn naam is {Name} {LastName}, ik ben {Age} jaar oud. " +
                $"Adressen: {addressesText}. Emails: {emailsText}. Telefoons: {phonesText}"
            );
        }
    }
}
