// Import the SurveyResponses model from survey.Models namespace
using survey.Models;

// Define the namespace for survey services
namespace survey.Service
{
    // Interface that defines the contract for Survey business logic operations
    // This interface specifies all methods that must be implemented by SurveyService
    public interface ISurveyService
    {
        // Method to import CSV data into database through business logic layer
        // Takes a file path as parameter and delegates to repository for CSV import
        void ImportCSVToDatabase(string filePath);
        
        // Method to get all survey responses through business logic layer
        // Returns a list of all SurveyResponses objects by delegating to repository
        List<SurveyResponses> GetAllSurveyResponses();
        
        // Method to count feedbacks by type through business logic layer
        // Takes a feedback type string and returns count by delegating to repository
        int CountFeedbacksByType(string feedbackType);
        
        // Method to get average age through business logic layer
        // Returns the average age as double by delegating to repository
        double GetAverageAge();
        
        // Method to get all occupation types through business logic layer
        // Returns list of unique occupation types by delegating to repository
        List<string> GetAllOccupationTypes();
        
        // Method to get responses by family size through business logic layer
        // Takes family size integer and returns filtered responses by delegating to repository
        List<SurveyResponses> GetResponsesByFamilySize(int familySize);
        
        // Method to export to AI train data through business logic layer
        // Delegates to repository to export data to AI training format
        void ExportToAITrainData();
        
        // Method to export survey responses to CSV file through business logic layer
        // Takes a list of responses and filename, exports data to CSV format
        void ExportToCSV(List<SurveyResponses> responses, string fileName);
    }
} 
