// Define the namespace for survey models
namespace survey.Models;

// Main survey response model class that represents a complete survey response
// This class maps to the SurveyResponses table in the database
public class SurveyResponses
{
    // Unique identifier for the survey response (auto-incremented in database)
    public int Id { get; set; }
    
    // Age of the person who completed the survey (integer value)
    public int Age { get; set; }
    
    // Gender of the person (string value - e.g., "Male", "Female")
    public string Gender { get; set; }
    
    // Marital status of the person (string value - e.g., "Single", "Married")
    public string MaritalStatus { get; set; }
    
    // Occupation of the person (string value - e.g., "Student", "Employee", "Self Employeed")
    public string Occupation { get; set; }
    
    // Monthly income of the person (string value - e.g., "Below Rs.10000", "More than 50000")
    public string MonthlyIncome { get; set; }
    
    // Educational qualifications of the person (string value - e.g., "Graduate", "Post Graduate", "Ph.D")
    public string EducationalQualifications { get; set; }

    // Number of family members (integer value)
    public int FamilySize { get; set; }

    // Latitude coordinate of the person's location (double value for GPS coordinates)
    public double Latitude { get; set; }

    // Longitude coordinate of the person's location (double value for GPS coordinates)
    public double Longitude { get; set; }

    // Postal code or PIN code of the person's location (string value)
    public string PinCode { get; set; }

    // Boolean output indicating survey result (true/false or Yes/No converted to boolean)
    public Boolean Output { get; set; }
    
    // Feedback provided by the person (string value - e.g., "Positive", "Negative")
    public string Feedback { get; set; }
}