using System.ComponentModel;           // (Niet gebruikt in dit voorbeeld, kan waarschijnlijk weg)
using animals.models;                   // Importeert de namespace waar Animal en Dog klassen gedefinieerd zijn

// Maak 2 Animal-objecten aan met naam en leeftijd
Animal a1 = new Animal("octupus", 12);
Animal a2 = new Animal("horse", 7);

// Roep de methode MakeSound() aan op beide Animal-objecten
// (De implementatie bepaalt welk geluid er wordt gemaakt)
a1.MakeSound();
a2.MakeSound();

// Maak 2 Dog-objecten aan met naam, leeftijd en ras (Breed)
Dog d1 = new Dog("lassie", 12, "goldenretriever");
d1.MakeSound(); // Hond maakt geluid

Dog d2 = new Dog("kifner", 23, "jack russsel terrier");
d2.MakeSound(); // Hond maakt geluid

// Maak een lijst van Animal-objecten en voeg de 2 dieren toe
List<Animal> animals = new List<Animal> { a1, a2 };

// Loop door elk Animal in de lijst en toon naam en leeftijd
foreach (var animal in animals)
{
    Console.WriteLine($"Name:{animal.Name} Age:{animal.Age}");
}

// Maak een lijst van Dog-objecten en voeg de 2 honden toe
List<Dog> dogs = new List<Dog> { d1, d2 };

// Loop door elk Dog in de lijst en toon naam, leeftijd en ras
foreach (var dog in dogs)
{
    Console.WriteLine($" Name: {dog.Name} Age: {dog.Age} Breed: {dog.Breed}");
}
