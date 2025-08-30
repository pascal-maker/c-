using Pascale.Models;
using System.Collections.Generic;

// Eerst maken we aparte adres-objecten
Addresse a1 = new Addresse("Amand Casier de Terbekenlaan", 23, 9030);
Addresse a2 = new Addresse("Konijnweg", 69, 9030);

// Daarna maken we lijsten van e-mailadressen en telefoonnummers
List<string> EmailAddresses = new List<string>
{
    "homorsimpson@gmail.com",
    "margesimpson@gmail.com",
    "maggiesimpson@gmail.com"
};

List<string> PhoneNumbers = new List<string>
{
    "+147575858585",
    "0948585858585",
    "40955995894949494"
};

// Twee personen maken met "new Person(...)" en hun adressen/emails/telefoons meegeven
Person p1 = new Person("Homer", "Simpson", 89, new List<Addresse> { a1 }, EmailAddresses, PhoneNumbers);
Person p2 = new Person("Marge", "Simpson", 44, new List<Addresse> { a1, a2 }, EmailAddresses, PhoneNumbers);

// Laat elke persoon zichzelf voorstellen via Introduce()
p1.Introduce();
p2.Introduce();

Console.WriteLine("\n--- Displaying Person Objects ---");

// Personen in een lijst steken
List<Person> people = new List<Person> { p1, p2 };

// Door de lijst lopen met foreach en elke persoon tonen via ToString()
foreach (var person in people)
{
    Console.WriteLine(person);
}
