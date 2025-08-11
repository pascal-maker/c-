using Exercise04.Data;
using Exercise04.Models;
using Exercise04.Repositories;
using Exercise04.Services;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseMySQL("server=localhost;user=root;password=9370;database=Exercise04_clean");

var context = new AppDbContext(optionsBuilder.Options);

// Ensure database is created
context.Database.EnsureCreated();

// Repositories
var travelerRepo = new TravelRepository(context);
var destinationRepo = new DestinationRepository(context);
var passportRepo = new PassportRepository(context);
var guideRepo = new GuideRepository(context);
var tourRepo = new TourRepository(context);

// Services
var travelerService = new TravelerService(travelerRepo);
var passportService = new PassportService(passportRepo, travelerRepo);
var travelerDestinationService = new TravelerDestinationService(travelerRepo, destinationRepo);
var destinationService = new DestinationService(destinationRepo);
var guideService = new GuideService(guideRepo);
var tourService = new TourService(tourRepo);

while (true)
{
    Console.WriteLine("\n=== TRAVEL AGENCY MENU ===");
    Console.WriteLine("1. Add Traveler");
    Console.WriteLine("2. Assign Passport to Traveler");
    Console.WriteLine("3. Assign Destination to Traveler");
    Console.WriteLine("4. Show All Travelers");
    Console.WriteLine("5. Add Destination");
    Console.WriteLine("6. Show All Destinations");
    Console.WriteLine("7. Add Guide");
    Console.WriteLine("8. Add Tour for Guide");
    Console.WriteLine("9. Show All Tours");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            Console.Write("Traveler full name: ");
            string fullName = Console.ReadLine();
            travelerService.AddTraveler(fullName);
            Console.WriteLine("Traveler added.");
            break;

        case "2":
            Console.Write("Traveler ID: ");
            int travelerId = int.Parse(Console.ReadLine());
            Console.Write("Passport Number: ");
            string passportNumber = Console.ReadLine();
            passportService.AssignPassport(travelerId, passportNumber);
            Console.WriteLine("Passport assigned.");
            break;

        case "3":
            Console.Write("Traveler ID: ");
            int tid = int.Parse(Console.ReadLine());
            Console.Write("Destination ID: ");
            int did = int.Parse(Console.ReadLine());
            travelerDestinationService.AssignDestination(tid, did);
            Console.WriteLine("Destination assigned.");
            break;

        case "4":
            var travelers = travelerService.GetAllTravelers();
            travelers.ForEach(t => Console.WriteLine($"{t.Id}: {t.FullName} - Passport: {t.Passport?.PassportNumber ?? "None"} - Destinations: {string.Join(", ", t.Destinations.Select(d => d.Name))}"));
            break;

        case "5":
            Console.Write("Destination name: ");
            string destName = Console.ReadLine();
            destinationService.AddDestination(destName);
            Console.WriteLine("Destination added.");
            break;

        case "6":
            var destinations = destinationService.GetAllDestinations();
            destinations.ForEach(d => Console.WriteLine($"{d.Id}: {d.Name}"));
            break;

        case "7":
            Console.Write("Guide name: ");
            string guideName = Console.ReadLine();
            guideService.AddGuide(guideName);
            Console.WriteLine("Guide added.");
            break;

        case "8":
            Console.Write("Tour title: ");
            string title = Console.ReadLine();
            Console.Write("Guide ID: ");
            int gid = int.Parse(Console.ReadLine());
            tourService.AddTour(title, gid);
            Console.WriteLine("Tour added.");
            break;

        case "9":
            var tours = tourService.GetAllTours();
            tours.ForEach(t => Console.WriteLine($"{t.Id}: {t.Title} - Guide: {t.Guide?.Name ?? "Unknown"}"));
            break;

        case "0":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}