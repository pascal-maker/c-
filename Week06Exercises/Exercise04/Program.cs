// Travel Agency Management System
// This program provides a console-based interface for managing a travel agency
// including travelers, passports, destinations, guides, and tours.

using Exercise04.Data;
using Exercise04.Models;
using Exercise04.Repositories;
using Exercise04.Services;
using Microsoft.EntityFrameworkCore;

// Configure database connection using Entity Framework Core
// Set up MySQL connection string with local database
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseMySQL("server=localhost;user=root;password=9370;database=Exercise04_clean");

// Create database context instance
var context = new AppDbContext(optionsBuilder.Options);

// Ensure database is created with all required tables
context.Database.EnsureCreated();

// Initialize repository instances for data access layer
// Each repository handles CRUD operations for a specific entity
var travelerRepo = new TravelRepository(context);
var destinationRepo = new DestinationRepository(context);
var passportRepo = new PassportRepository(context);
var guideRepo = new GuideRepository(context);
var tourRepo = new TourRepository(context);

// Initialize service layer instances
// Services contain business logic and coordinate between repositories
var travelerService = new TravelerService(travelerRepo);
var passportService = new PassportService(passportRepo, travelerRepo);
var travelerDestinationService = new TravelerDestinationService(travelerRepo, destinationRepo);
var destinationService = new DestinationService(destinationRepo);
var guideService = new GuideService(guideRepo);
var tourService = new TourService(tourRepo);

// Main application loop - provides interactive menu system
while (true)
{
    // Display main menu options
    Console.WriteLine("\n=== Travel AGENCY MENU====");
    Console.WriteLine("1. Add Traveler");
    Console.WriteLine("2.Assign Passport to Traveler");
    Console.WriteLine("3.Assign Destination to Traveler");
    Console.WriteLine("4.Show all Travelers");
    Console.WriteLine("5.Add Destination");
    Console.WriteLine("6.Show all Destinations");
    Console.WriteLine("7.Add Guide");
    Console.WriteLine("8. Add Tour for Guide");
    Console.WriteLine("9.Show all Tours");
    Console.WriteLine("0.Exit");
    Console.Write("Enter your choice:");

    // Get user input for menu selection
    string choice = Console.ReadLine();
    Console.WriteLine();

    // Process user selection using switch statement
    switch (choice)
    {
        case "1":
            // Add new traveler functionality
            Console.Write("Traveler full name:");
            string fullName = Console.ReadLine();
            travelerService.AddTraveler(fullName);
            Console.WriteLine("Traveler Added.");
            break;

        case "2":
            // Assign passport to existing traveler
            Console.Write("Traveler ID:");
            int travelerId = int.Parse(Console.ReadLine());
            Console.Write("Passport Number:");
            string passportNumber = Console.ReadLine();
            passportService.AssignPassport(travelerId, passportNumber);
            Console.WriteLine("Passport Assigned");
            break;

        case "3":
            // Assign destination to traveler (many-to-many relationship)
            Console.Write("Traveler ID:");
            int tid = int.Parse(Console.ReadLine());
            Console.Write("Destination Id:");
            int did = int.Parse(Console.ReadLine());
            travelerDestinationService.AssignDestination(tid, did);
            Console.WriteLine("Destination Assigned");
            break;

        case "4":
            // Display all travelers with their associated passports and destinations
            var travelers = travelerService.GetAllTravelers();
            travelers.ForEach(t => Console.WriteLine($"{t.Id}: {t.FullName} - Passport: {t.Passport.PassportNumber} -Destinations:{string.Join(",", t.Destinations.Select(d => d.Name))}"));
            break;
        case "5":
            // Add new destination to the system
            Console.Write("Destination name:");
            string destName = Console.ReadLine();
            destinationService.AddDestination(destName);
            Console.WriteLine("Destination added.");
            break;
        case "6":
            // Display all available destinations
            var destinations = destinationService.GetAllDestinations();
            destinations.ForEach(d => Console.WriteLine($"{d.Id} {d.Name}"));
            break;

        case "7":
            // Add new guide to the system
            Console.Write("Guide name:");
            string guideName = Console.ReadLine();
            guideService.AddGuide(guideName);
            Console.WriteLine("Guide added.");
            break;

        case "8":
            // Create new tour and assign it to a guide
            Console.Write("Tour title:");
            string title = Console.ReadLine();
            Console.Write("Guide ID:");
            int gid = int.Parse(Console.ReadLine());
            tourService.AddTour(title, gid);
            Console.WriteLine("Tour added.");
            break;
        case "9":
            // Display all tours with their assigned guides
            var tours = tourService.GetAllTours();
            tours.ForEach(t => Console.WriteLine($"{t.Id} {t.Title} -Guide: {t.Guide.Name}"));
            break;

        case "0":
            // Exit the application
            Console.WriteLine("Goodbye!");
            return;

        default:
            // Handle invalid menu selections
            Console.WriteLine("Invalid choice.Try again.");
            break;      










    }

}


