using CTANDAI.CarReservationSystem.NonAsync.Services;   // Import the namespace that contains the CarService and CarReservationService
using CTANDAI.CarReservationSystem.NonAsync.Repositories; // Import repositories (data access layer)
using CTANDAI.CarReservationSystem; // Import constants and other core system files
using System.Text; // Needed for StringBuilder (used when creating CSV files)

namespace CTANDAI.CarReservationSystem.NonAsync
{
    class Program
    {
        // Entry point of the application (synchronous version)
        static void Main(string[] args)
        {
            // Create repository instances (repositories talk directly to the database)
            var carRepository = new CarRepository(Constants.ConnectionString);
            var reservationRepository = new CarReservationRepository(Constants.ConnectionString);

            // Create service instances (services contain the business logic, using the repositories to save/retrieve data)
            var carService = new CarService(carRepository);
            var reservationService = new CarReservationService(reservationRepository, carRepository);

            // Boolean flag to control the while loop (true = exit the program)
            bool exit = false;

            // Main menu loop
            while (!exit)
            {
                Console.Clear(); // Clears the console screen for better readability
                Console.WriteLine("Car Reservation System");
                Console.WriteLine("1. Import Cars from API");
                Console.WriteLine("2. Add Reservation");
                Console.WriteLine("3. Show Reservations");
                Console.WriteLine("4. Total Cost of Reservations");
                Console.WriteLine("5. Update Reservation");
                Console.WriteLine("6. Export Reservations to CSV");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: "); // Ask user to choose an option
                var choice = Console.ReadLine(); // Read user input as a string

                try
                {
                    // Check which option the user selected
                    switch (choice)
                    {
                        case "1":
                            // Import cars from an online API
                            ImportCarsFromApi(carService);
                            // This method is now synchronous
                            break;

                        case "2":
                            // Add a new reservation
                            AddReservation(reservationService, carService);
                            break;

                        case "3":
                            // Show all reservations
                            ShowReservations(reservationService);
                            break;

                        case "4":
                            // Show the total cost of all reservations
                            ShowTotalCost(reservationService);
                            break;

                        case "5":
                            // Update an existing reservation
                            UpdateReservation(reservationService, carService);
                            break;

                        case "6":
                            // Export reservations to a CSV file
                            ExportReservationsToCsv(reservationService);
                            break;

                        case "0":
                            // Exit the program
                            exit = true;
                            Console.WriteLine("Exiting the application...");
                            break;

                        default:
                            // Handle invalid input
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex) // Catch any errors that happen during execution
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // Method to import cars from the API (synchronous version)
        static void ImportCarsFromApi(CarService carService)
        // This method fetches cars from an external API and saves them to the database
        {
            Console.WriteLine("Importing cars from API...");
            var cars = carService.ImportCarsFromApi(); // Fetch and save cars
            // If the API call was successful, cars will be saved in the database
            Console.WriteLine($"Imported {cars.Count} cars from API.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to add a reservation
        static void AddReservation(CarReservationService reservationService, CarService carService)
        {
            Console.WriteLine("Adding a new reservation...");

            // Ask for customer details
            Console.Write("Enter Customer Name: ");
            var customerName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Duration (in days): ");
            var duration = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Is Electric Car Required? (yes/no): ");
            var electricRequired = Console.ReadLine()?.ToLower() == "yes"; // true if user types yes

            // Show all available cars
            Console.WriteLine("Available Cars:");
            var cars = carService.GetAllCars();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.Brand} {car.Model} - {car.PricePerDay:C} per day");
            }

            Console.Write("Enter Car ID: ");
            var carId = int.Parse(Console.ReadLine() ?? "0");

            // Add the reservation through the service
            reservationService.AddReservation(customerName, duration, electricRequired, carId);
            Console.WriteLine("Reservation added successfully.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to display all reservations
        static void ShowReservations(CarReservationService reservationService)
        {
            Console.WriteLine("Showing all reservations...");
            var reservations = reservationService.GetAllReservations();
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"ID: {reservation.Id}, Customer: {reservation.CustomerName}, Duration: {reservation.Duration} days, Cost: {reservation.Cost:C}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to display the total cost of all reservations
        static void ShowTotalCost(CarReservationService reservationService)
        // This method calculates and displays the total cost of all reservations
        {
            Console.WriteLine("Calculating total cost of all reservations...");
            // Get all reservations and sum their cost
            var totalCost = reservationService.GetAllReservations().Sum(r => r.Cost);
            Console.WriteLine($"Total Cost: {totalCost:C}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to update an existing reservation
        static void UpdateReservation(CarReservationService reservationService, CarService carService)
        // This method allows the user to update an existing reservation
        {
            Console.WriteLine("Updating a reservation...");
            Console.Write("Enter Reservation ID: ");
            var reservationId = int.Parse(Console.ReadLine() ?? "0");

            // Get the existing reservation
            var reservation = reservationService.GetReservationById(reservationId);
            if (reservation == null)
            {
                Console.WriteLine("Reservation not found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return; // Exit method if reservation doesn't exist
            }

            // Ask for new values, allow user to keep current if they leave blank
            Console.Write("Enter New Customer Name (leave empty to keep current): ");
            // Use null-coalescing operator to handle empty input
            var customerName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(customerName))
            {
                customerName = reservation.CustomerName;
            }

            Console.Write("Enter New Duration (in days, leave empty to keep current): ");
            var durationInput = Console.ReadLine();
            var duration = string.IsNullOrEmpty(durationInput) ? reservation.Duration : int.Parse(durationInput);
            // Ask if electric car is required

            Console.Write("Is Electric Car Required? (yes/no, leave empty to keep current): ");
            var electricRequiredInput = Console.ReadLine();
            var electricRequired = string.IsNullOrEmpty(electricRequiredInput) ? reservation.ElectricRequired : electricRequiredInput.ToLower() == "yes";
            //checking string is empty or not, if empty then keep current value

            // Show all available cars
            Console.WriteLine("Available Cars:");
            var cars = carService.GetAllCars();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.Brand} {car.Model} - {car.PricePerDay:C} per day");
            }

            Console.Write("Enter New Car ID (leave empty to keep current): ");
            var carIdInput = Console.ReadLine();
            var carId = string.IsNullOrEmpty(carIdInput) ? reservation.CarId : int.Parse(carIdInput);
            // same logic here but for car ID

            // Update reservation via service
            reservationService.UpdateReservation(reservationId, customerName, duration, electricRequired, carId);
            // This will update the reservation in the database
            Console.WriteLine("Reservation updated successfully.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Method to export reservations to a CSV file
        static void ExportReservationsToCsv(CarReservationService reservationService)
        // This method exports all reservations to a CSV file named "reservations.csv"
        {
            Console.WriteLine("Exporting reservations to CSV...");

            var reservations = reservationService.GetAllReservations(); // Get all reservations
            var csvContent = new StringBuilder(); // Used to build the CSV file content in memory
            csvContent.AppendLine("Id,CustomerName,Duration,Cost,ElectricRequired,CarId"); // CSV header

            // Add each reservation as a line in CSV
            foreach (var reservation in reservations)
            {
                csvContent.AppendLine($"{reservation.Id},{reservation.CustomerName},{reservation.Duration},{reservation.Cost},{reservation.ElectricRequired},{reservation.CarId}");
            }
            // This creates a CSV line for each reservation with its properties

            // Save the CSV file to the local disk
            File.WriteAllText("reservations.csv", csvContent.ToString());
            Console.WriteLine("Reservations exported to reservations.csv");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
