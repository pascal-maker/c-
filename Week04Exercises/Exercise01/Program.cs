using Ct.Ai.Models;
using Ct.Ai.Repositories;
using Ct.Ai.Services;
using System;

namespace Ct.Ai
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new SmartPhoneRepository();
            var service = new SmartPhoneService(repo);

            //Creates a repository object that handles data storage/retrieval for smartphones (e.g., reading/writing from CSV).


//Creates a service layer that uses the repository (repo) to perform higher-level operations like adding, searching, etc.

//This helps keep business logic separate from raw data access.

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Smartphone Catalog ===");
                Console.WriteLine("1. List all smartphones");
                Console.WriteLine("2. Search smartphones");
                Console.WriteLine("3. Add new smartphone");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (var s in service.GetAll()) Console.WriteLine(s);
                        break;

                    case "2":
                        Console.Write("Enter brand or type:");
                        string query = Console.ReadLine();
                        var results = service.Search(query);
                        if (results.Count == 0) Console.WriteLine(" No results found.");
                        else results.ForEach(Console.WriteLine);
                        break;

                    case "3":
                        var phone = new Smartphone();
                        Console.Write("Brand:");
                        phone.Brand = Console.ReadLine();
                        Console.Write("Type:");
                        phone.Type = Console.ReadLine();
                        Console.Write("Release Year:");
                        phone.ReleaseYear = int.Parse(Console.ReadLine());
                        Console.Write("Start Price:");
                        phone.StartPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Operating System:");
                        phone.OperatingSystem = Console.ReadLine();

                        service.Add(phone);
                        Console.WriteLine("Smartphone added.");
                        break;

                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine(" Invalid option.");
                        break;
                }
            }
        }
    }
}