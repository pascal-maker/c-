// Import the SurveyResponses model from survey.Models namespace
using survey.Models;
// Import MySQL data client for database operations
using MySql.Data.MySqlClient;

// Define the namespace for survey repositories
namespace survey.Repositories;

// Interface that defines the contract for Survey data access operations
// This interface specifies all methods that must be implemented by SurveyRepository
public interface ISurveyRepository
{
    // Method to import CSV data into the database
    // Takes a file path as parameter and reads CSV file to populate database
    void ImportCSVToDatabase(string filepath);
    
    // Method to retrieve all survey responses from the database
    // Returns a list of all SurveyResponses objects stored in the database
    List<SurveyResponses> GetAllSurveyRespones();
    
    // Method to count feedbacks by specific feedback type
    // Takes a feedback type string and returns the count of responses with that feedback
    int CountFeedbacksByType(string feedbackType);
    
    // Method to calculate the average age of all survey responses
    // Returns the average age as a double value
    double GetAverageAge();

    // Method to get all unique occupation types from the database
    // Returns a list of distinct occupation values found in the survey responses
    List<String> GetAllOccupationTypes();
    
    // Method to get survey responses filtered by family size
    // Takes a family size integer and returns all responses with that family size
    List<SurveyResponses> GetResponsesByFamilySize(int familysize);
    
    // Method to export all survey responses to AI train data format in the database
    // Copies data from SurveyResponses table to AITrainData table for machine learning
    void ExportToAITRainData();
    
    // Method to clear all data from both database tables
    // Removes all records from SurveyResponses and AITrainData tables
    void ClearAllData();
}