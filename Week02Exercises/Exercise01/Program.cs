using Pascal.Models;
// Twee personen maken met "new Person(...)"
// => Zonder "new" bestaat er nog geen object in het geheugen
Person p1  = new Person("Donald","trump",88,"fifth aveneue","donaldtrump@gmail.com","+14585858585");

Person p2 = new Person("Baron","trump",18,"fifth aveneue","donaldtrump@gmail.com","+1458538383");
// Methode aanroepen zonder parameters, want alle data zit al in het object

p1.Introduce();
p2.Introduce();

// Methode aanroepen zonder parameters, want alle data zit al in het object

List<Person> people = new List<Person> {p1,p2};
// Door de lijst lopen met foreach en iedereen laten voorstellen
foreach ( var person in people)
{
    person.Introduce();
}