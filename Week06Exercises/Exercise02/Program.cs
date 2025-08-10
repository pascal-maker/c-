using Exercise02.Models;
using Exercise02.Repository;
using Exercise02.Service;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new SurveyRepository();
            var service = new SurveyService(repository);

            Menu();

            void Menu()
            {
                while (true)
                {
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
                        ImportCSV();
                        break;
                    case "2":
                        ViewAllResponses();
                        break;
                    case "3":
                        CountFeedbacks();
                        break;
                    case "4":
                        ShowAverageAge();
                        break;
                    case "5":
                        ShowOccupationTypes();
                        break;
                    case "6":
                        ExportByFamilySize();
                        break;
                    case "7":
                        ExportToAITrainData();
                        break;
                    case "8":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose 1-8.");
                        break;
                }
            }

            void ImportCSV()
            {
                Console.WriteLine("=== Import CSV to Database ===");
                var filePath = "data/onlinefoods .csv";
                
                if (File.Exists(filePath))
                {
                    service.ImportCSVToDatabase(filePath);
                    Console.WriteLine("CSV data imported successfully!");
                }
                else
                {
                    Console.WriteLine($"File not found: {filePath}");
                }
            }

            void ViewAllResponses()
            {
                Console.WriteLine("=== All Survey Responses ===");
                var responses = service.GetAllSurveyResponses();
                
                if (responses.Count == 0)
                {
                    Console.WriteLine("No survey responses found in database.");
                }
                else
                {
                    Console.WriteLine($"Found {responses.Count} survey responses:");
                    Console.WriteLine("ID | Age | Gender | Marital Status | Occupation | Monthly Income | Family Size | Feedback");
                    Console.WriteLine(new string('-', 100));
                    
                    foreach (var response in responses)
                    {
                        Console.WriteLine($"{response.Id} | {response.Age} | {response.Gender} | {response.MaritalStatus} | " +
                                         $"{response.Occupation} | {response.MonthlyIncome} | {response.FamilySize} | {response.Feedback}");
                    }
                }
            }

            void CountFeedbacks()
            {
                Console.WriteLine("=== Count Feedbacks by Type ===");
                Console.Write("Enter feedback type (Positive/Negative): ");
                var feedbackType = Console.ReadLine();
                
                var count = service.CountFeedbacksByType(feedbackType);
                Console.WriteLine($"Total {feedbackType} feedbacks: {count}");
            }

            void ShowAverageAge()
            {
                Console.WriteLine("=== Average Age ===");
                var averageAge = service.GetAverageAge();
                Console.WriteLine($"Average age of all survey responses: {averageAge:F2} years");
            }

            void ShowOccupationTypes()
            {
                Console.WriteLine("=== All Occupation Types ===");
                var occupations = service.GetAllOccupationTypes();
                
                if (occupations.Count == 0)
                {
                    Console.WriteLine("No occupation types found.");
                }
                else
                {
                    Console.WriteLine($"Found {occupations.Count} occupation types:");
                    foreach (var occupation in occupations)
                    {
                        Console.WriteLine($"- {occupation}");
                    }
                }
            }

            void ExportByFamilySize()
            {
                Console.WriteLine("=== Export by Family Size ===");
                Console.Write("Enter family size: ");
                var familySize = int.Parse(Console.ReadLine());
                
                Console.Write("Enter CSV file name (e.g., output.csv): ");
                var fileName = Console.ReadLine();
                
                var responses = service.GetResponsesByFamilySize(familySize);
                
                if (responses.Count == 0)
                {
                    Console.WriteLine($"No responses found with family size {familySize}.");
                }
                else
                {
                    service.ExportToCSV(responses, fileName);
                    Console.WriteLine($"Exported {responses.Count} records to {fileName}");
                }
            }

            void ExportToAITrainData()
            {
                Console.WriteLine("=== Export to AI Train Data ===");
                service.ExportToAITrainData();
                Console.WriteLine("Survey responses exported to AI train data format successfully!");
            }
        }
    }
}