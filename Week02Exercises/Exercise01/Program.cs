using Pascal.Models;

Person p1 = new Person("pascal", "musabyimana", 24, "gerard willemotlaan30", "pascal-musa@hotmail.com", "0456180134");
Person p2 = new Person("joseph", "musabyimana", 24, "gerard willemotlaan30", "pascal-musa@hotmail.com", "04549488");
p1.Introduce("pascal", "musabyimana", 24, "gerard willemotlaan30", "pascal-musa@hotmail.com", "0456180134");
p2.Introduce("joseph", "musabyimana", 24, "gerard willemotlaan30", "pascal-musa@hotmail.com", "04549488");

List<Person> people = new List<Person> { p1, p2 };
foreach (var person in people)
{
    Console.WriteLine($" {person}");
}
