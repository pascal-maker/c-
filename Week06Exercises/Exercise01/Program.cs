using Exercise01.Models;
using Exercise01.Repository;
using Exercise01.Service;

namespace Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            var personRepository = new PersonRepository();
            var personService = new PersonService(personRepository);

            Menu();

            void Menu()
            {
                while (true)
                {
                    Console.WriteLine("\n=== Person Management System ===");
                    Console.WriteLine("1. Add Person");
                    Console.WriteLine("2. Update a person");
                    Console.WriteLine("3. Delete a person");
                    Console.WriteLine("4. Get a Person by his Id");
                    Console.WriteLine("5. Get all persons");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose an option: ");
                    
                    var option = Console.ReadLine();
                    Console.WriteLine();
                    
                    ParseOption(option);
                }
            }

            void ParseOption(string option)
            {
                switch (option)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        UpdatePerson();
                        break;
                    case "3":
                        DeletePerson();
                        break;
                    case "4":
                        GetPersonById();
                        break;
                    case "5":
                        GetAllPersons();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose 1-6.");
                        break;
                }
            }

            void AddPerson()
            {
                Console.WriteLine("=== Add New Person ===");
                Console.Write("Id: ");
                var id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write("Age: ");
                var age = int.Parse(Console.ReadLine());
                Console.Write("Email: ");
                var email = Console.ReadLine();

                var person = new Exercise01.Models.Person
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Email = email
                };
                personService.AddPerson(person);
                Console.WriteLine("Person added successfully!");
            }

            void UpdatePerson()
            {
                Console.WriteLine("=== Update Person ===");
                Console.Write("Enter the Id of the person to update: ");
                var id = int.Parse(Console.ReadLine());
                Console.Write("New Name: ");
                var name = Console.ReadLine();
                Console.Write("New Age: ");
                var age = int.Parse(Console.ReadLine());
                Console.Write("New Email: ");
                var email = Console.ReadLine();

                var person = new Exercise01.Models.Person
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Email = email
                };
                personService.UpdatePerson(person);
                Console.WriteLine("Person updated successfully!");
            }

            void DeletePerson()
            {
                Console.WriteLine("=== Delete Person ===");
                Console.Write("Enter the Id of the person to delete: ");
                var id = int.Parse(Console.ReadLine());
                personService.DeletePerson(id);
                Console.WriteLine("Person deleted successfully!");
            }

            void GetPersonById()
            {
                Console.WriteLine("=== Find Person by Id ===");
                Console.Write("Enter the Id of the person to find: ");
                var id = int.Parse(Console.ReadLine());
                personService.GetPersonById(id);
            }

            void GetAllPersons()
            {
                Console.WriteLine("=== All Persons ===");
                var people = personService.GetAllPersons();
                if (people.Count == 0)
                {
                    Console.WriteLine("No persons found.");
                }
                else
                {
                    Console.WriteLine($"Found {people.Count} person(s):");
                    foreach (var person in people)
                    {
                        Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
                    }
                }
            }
        }
    }
}

