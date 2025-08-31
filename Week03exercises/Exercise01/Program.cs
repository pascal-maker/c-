using animals.models;
using System.Collections.Generic;

// Maak enkele Animal-objecten
Animal a1 = new Animal("Octopus", 12);
a1.MakeSound(); // "unknown sound"
Animal a2 = new Animal("Panda", 1);
a2.MakeSound(); // "unknown sound"

// Maak enkele Dog-objecten
Dog d1 = new Dog("Blackie", 12, "German Shepherd");
d1.MakeSound(); // "Wooof"

Dog d2 = new Dog("Finn", 2, "Golden Retriever");
d2.MakeSound(); // "Wooof"

// Zet Animals in een lijst → kan zowel Octopus als Panda bevatten
List<Animal> animals = new List<Animal> { a1, a2 };

// Doorloop de lijst met Animals
foreach (var animal in animals)
{
    Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");
}

// Zet Dogs in een aparte lijst
List<Dog> dogs = new List<Dog> { d1, d2 };

// Doorloop de lijst met Dogs
foreach (var dog in dogs)
{
    Console.WriteLine($"Age: {dog.Age}, Name: {dog.Name}, Breed: {dog.Breed}");
}
