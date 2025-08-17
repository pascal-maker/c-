// Import required namespaces for service layer operations
using survey.Repositories;  // Import repository interfaces and implementations
using survey.Models;  // Import survey model classes
using CsvHelper;  // Import CSV helper library for CSV operations
using CsvHelper.Configuration;  // Import CSV configuration for custom settings
using System.Globalization;  // Import culture information for CSV formatting

// Define the namespace for survey services
namespace survey.Service
{
    // Implementation of ISurveyService that handles business logic for Survey operations
    // This class acts as a bridge between the UI layer and the repository layer
    public class SurveyService : ISurveyService
    {
        // Private readonly field to store the survey repository dependency
        // This follows the Dependency Injection pattern for loose coupling
        private readonly ISurveyRepository _repository;

        // Constructor that accepts repository dependencies (Dependency Injection pattern)
        // This allows for easy testing and swapping of repository implementations
        public SurveyService(ISurveyRepository repository)
        {
            // Assign the injected repository to the private field
            _repository = repository;
        }

        // Method to import CSV data into database by delegating to the survey repository
        // This method simply passes through the call to the repository layer
        public void ImportCSVToDatabase(string filePath)
        {
            // Call the survey repository's ImportCSVToDatabase method
            _repository.ImportCSVToDatabase(filePath);
        }

        // Method to get all survey responses by delegating to the survey repository
        // This method returns the result from the repository layer
        public List<SurveyResponses> GetAllSurveyResponses()
        {
            // Return the result from the survey repository's GetAllSurveyResponses method
            return _repository.GetAllSurveyResponses();
        }

        // Method to count feedbacks by type by delegating to the survey repository
        // This method returns the count from the repository layer
        public int CountFeedbacksByType(string feedbackType)
        {
            // Return the result from the survey repository's CountFeedbacksByType method
            return _repository.CountFeedbacksByType(feedbackType);
        }

        // Method to get average age by delegating to the survey repository
        // This method returns the average age from the repository layer
        public double GetAverageAge()
        {
            // Return the result from the survey repository's GetAverageAge method
            return _repository.GetAverageAge();
        }

        // Method to get all occupation types by delegating to the survey repository
        // This method returns the list of occupation types from the repository layer
        public List<string> GetAllOccupationTypes()
        {
            // Return the result from the survey repository's GetAllOccupationTypes method
            return _repository.GetAllOccupationTypes();
        }

        // Method to get responses by family size by delegating to the survey repository
        // This method returns the filtered responses from the repository layer
        public List<SurveyResponses> GetResponsesByFamilySize(int familySize)
        {
            // Return the result from the survey repository's GetResponsesByFamilySize method
            return _repository.GetResponsesByFamilySize(familySize);
        }

        // Method to export to AI train data by delegating to the survey repository
        // This method calls the repository to export data to AI training format
        public void ExportToAITrainData()
        {
            // Call the survey repository's ExportToAITRainData method
            _repository.ExportToAITRainData();
        }

        // Method to export survey responses to CSV file
        // This method handles the CSV export logic using CsvHelper library
        public void ExportToCSV(List<SurveyResponses> responses, string fileName)
        {
            // Create a StreamWriter to write to the CSV file
            using (var writer = new StreamWriter(fileName))
            // Create a CsvWriter with specific configuration for CSV formatting
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true  // Include header row in the CSV file
            }))
            {
                // Register the mapping class for consistent CSV formatting
                csv.Context.RegisterClassMap<SurveyReponsesMap>();
                
                // Write all survey response records to the CSV file
                csv.WriteRecords(responses);
            }
        }
    }
} 
