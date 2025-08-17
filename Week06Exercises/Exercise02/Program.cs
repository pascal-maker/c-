// Import required namespaces for the main program
using survey.Models;  // Import survey model classes (SurveyResponses, AITrainData)
using survey.Repositories;  // Import repository classes (SurveyRepository, ISurveyRepository)
using survey.Service;  // Import service classes (SurveyService, ISurveyService)

// Define the namespace for the main Survey application
namespace Survey
{
    // Main program class that contains the entry point and user interface
    class Program
    {
        // Main entry point of the application
        // This method is called when the program starts
        static void Main(string[] args)
        {
            // Create a new instance of SurveyRepository for data access operations
            var repository = new SurveyRepository();
            // Create a new instance of SurveyService and inject the repository dependency
            // This follows the Dependency Injection pattern for loose coupling
            var service = new SurveyService(repository);

            // Call the Menu method to start the user interface
            Menu();

            // Method that displays the main menu and handles user interaction
            // This method runs in an infinite loop until the user chooses to exit
            void Menu()
            {
                // Infinite loop to keep the menu running
                while (true)
                {
                    // Display the application title and menu options
                    Console.WriteLine("\n=== Online Food Survey Management System ===");
                    Console.WriteLine("1. Import CSV into database");
                    Console.WriteLine("2. View All Survey Responses from database");
                    Console.WriteLine("3. Count total feedbacks based on feedback type");
                    Console.WriteLine("4. Average age of all survey responses");
                    Console.WriteLine("5. Show all occupation types");
                    Console.WriteLine("6. Export records by family size to CSV");
                    Console.WriteLine("7. Export all survey responses to AI train data format");
                    Console.WriteLine("8. Exit");
                    Console.Write("Choose an option: ");
                    
                    // Read the user's choice from the console
                    var option = Console.ReadLine();
                    Console.WriteLine();  // Add a blank line for better formatting
                    
                    // Parse and execute the user's choice
                    ParseOption(option);
                }
            }

            // Method that parses the user's menu choice and calls the appropriate function
            // Takes a string parameter representing the user's selection
            void ParseOption(string option)
            {
                // Switch statement to handle different menu options
                switch (option)
                {
                    case "1":
                        // Call the ImportCSV method to import CSV data into the database
                        ImportCSV();
                        break;
                    case "2":
                        // Call the ViewAllResponses method to display all survey responses
                        ViewAllResponses();
                        break;
                    case "3":
                        // Call the CountFeedbacks method to count feedbacks by type
                        CountFeedbacks();
                        break;
                    case "4":
                        // Call the ShowAverageAge method to display the average age
                        ShowAverageAge();
                        break;
                    case "5":
                        // Call the ShowOccupationTypes method to display all occupation types
                        ShowOccupationTypes();
                        break;
                    case "6":
                        // Call the ExportByFamilySize method to export data by family size
                        ExportByFamilySize();
                        break;
                    case "7":
                        // Call the ExportToAITrainData method to export to AI training format
                        ExportToAITrainData();
                        break;
                    case "8":
                        // Display goodbye message and exit the application
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);  // Terminate the application with exit code 0
                        break;
                    default:
                        // Handle invalid menu selections
                        Console.WriteLine("Invalid option. Please choose 1-8.");
                        break;
                }
            }

            // Method to import CSV data into the database
            // This method reads the CSV file and imports the data using the service layer
            void ImportCSV()
            {
                // Display the import operation header
                Console.WriteLine("=== Import CSV to Database ===");
                // Define the path to the CSV file (relative to the project directory)
                var filePath = "data/onlinefoods .csv";
                
                // Check if the CSV file exists at the specified path
                if (File.Exists(filePath))
                {
                    // Call the service method to import CSV data into the database
                    service.ImportCSVToDatabase(filePath);
                    // Display success message to the user
                    Console.WriteLine("CSV data imported successfully!");
                }
                else
                {
                    // Display error message if the file is not found
                    Console.WriteLine($"File not found: {filePath}");
                }
            }

            // Method to view all survey responses from the database
            // This method retrieves and displays all survey data in a formatted table
            void ViewAllResponses()
            {
                // Display the view responses header
                Console.WriteLine("=== All Survey Responses ===");
                // Call the service method to get all survey responses from the database
                var responses = service.GetAllSurveyResponses();
                
                // Check if there are any survey responses in the database
                if (responses.Count == 0)
                {
                    // Display message if no responses are found
                    Console.WriteLine("No survey responses found in database.");
                }
                else
                {
                    // Display the number of responses found
                    Console.WriteLine($"Found {responses.Count} survey responses:");
                    // Display the table header with column names
                    Console.WriteLine("ID | Age | Gender | Marital Status | Occupation | Monthly Income | Family Size | Feedback");
                    // Display a separator line for better table formatting
                    Console.WriteLine(new string('-', 100));
                    
                    // Loop through each survey response and display its details
                    foreach (var response in responses)
                    {
                        // Display each response in a formatted table row
                        Console.WriteLine($"{response.Id} | {response.Age} | {response.Gender} | {response.MaritalStatus} | " +
                                         $"{response.Occupation} | {response.MonthlyIncome} | {response.FamilySize} | {response.Feedback}");
                    }
                }
            }

            // Method to count feedbacks by specific feedback type
            // This method asks the user for a feedback type and displays the count
            void CountFeedbacks()
            {
                // Display the count feedbacks header
                Console.WriteLine("=== Count Feedbacks by Type ===");
                // Prompt the user to enter a feedback type
                Console.Write("Enter feedback type (Positive/Negative): ");
                // Read the user's input for feedback type
                var feedbackType = Console.ReadLine();
                
                // Call the service method to count feedbacks of the specified type
                var count = service.CountFeedbacksByType(feedbackType);
                // Display the count result to the user
                Console.WriteLine($"Total {feedbackType} feedbacks: {count}");
            }

            // Method to show the average age of all survey responses
            // This method calculates and displays the average age from the database
            void ShowAverageAge()
            {
                // Display the average age header
                Console.WriteLine("=== Average Age ===");
                // Call the service method to get the average age
                var averageAge = service.GetAverageAge();
                // Display the average age formatted to 2 decimal places
                Console.WriteLine($"Average age of all survey responses: {averageAge:F2} years");
            }

            // Method to show all unique occupation types
            // This method retrieves and displays all distinct occupation types from the database
            void ShowOccupationTypes()
            {
                // Display the occupation types header
                Console.WriteLine("=== All Occupation Types ===");
                // Call the service method to get all unique occupation types
                var occupations = service.GetAllOccupationTypes();
                
                // Check if there are any occupation types in the database
                if (occupations.Count == 0)
                {
                    // Display message if no occupation types are found
                    Console.WriteLine("No occupation types found.");
                }
                else
                {
                    // Display the number of occupation types found
                    Console.WriteLine($"Found {occupations.Count} occupation types:");
                    // Loop through each occupation type and display it
                    foreach (var occupation in occupations)
                    {
                        // Display each occupation type with a bullet point
                        Console.WriteLine($"- {occupation}");
                    }
                }
            }

            // Method to export survey responses by family size to a CSV file
            // This method asks for family size and filename, then exports the filtered data
            void ExportByFamilySize()
            {
                // Display the export by family size header
                Console.WriteLine("=== Export by Family Size ===");
                // Prompt the user to enter a family size
                Console.Write("Enter family size: ");
                // Read and parse the user's input for family size (convert string to integer)
                var familySize = int.Parse(Console.ReadLine());
                
                // Prompt the user to enter a CSV filename
                Console.Write("Enter CSV file name (e.g., output.csv): ");
                // Read the user's input for the filename
                var fileName = Console.ReadLine();
                
                // Call the service method to get responses with the specified family size
                var responses = service.GetResponsesByFamilySize(familySize);
                
                // Check if there are any responses with the specified family size
                if (responses.Count == 0)
                {
                    // Display message if no responses are found with the specified family size
                    Console.WriteLine($"No responses found with family size {familySize}.");
                }
                else
                {
                    // Call the service method to export the responses to a CSV file
                    service.ExportToCSV(responses, fileName);
                    // Display success message with the number of records exported
                    Console.WriteLine($"Exported {responses.Count} records to {fileName}");
                }
            }

            // Method to export all survey responses to AI train data format
            // This method copies data from SurveyResponses table to AITrainData table
            void ExportToAITrainData()
            {
                // Display the export to AI train data header
                Console.WriteLine("=== Export to AI Train Data ===");
                // Call the service method to export data to AI training format
                service.ExportToAITrainData();
                // Display success message to the user
                Console.WriteLine("Survey responses exported to AI train data format successfully!");
            }
        }
    }
}
