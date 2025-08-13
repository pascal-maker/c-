using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using Ct.Ai.Models;

namespace Ct.Ai.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Dog("Whiskers", 3, "Siamese");
            Console.WriteLine(animal.MakeSound());


            List<Animal> animals = new List<Animal>
            {
                new Dog("Blackie",23,"Golden Retriever"),
                new Dog("Spookie",2,"Terrier")
            };


            foreach (Animal dogs in animals)
            {
                Console.WriteLine(dogs.MakeSound());
            }


        }
    }
}
