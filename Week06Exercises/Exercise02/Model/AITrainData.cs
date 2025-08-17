// Define the namespace for survey models
namespace survey.Models;

// AI training data model class for machine learning purposes
// This class contains a subset of survey data specifically formatted for AI training
public class AITrainData
{
    // Age of the person (integer value)
    public int Age { get; set; }
    
    // Gender of the person (string value - e.g., "Male", "Female")
    public string Gender { get; set; }
    
    // Marital status of the person (string value - e.g., "Single", "Married")
    public string MaritalStatus { get; set; }
    
    // Occupation of the person (string value - e.g., "Student", "Employee")
    public string Occupation { get; set; }
    
    // Monthly income of the person (string value - e.g., "Below Rs.10000", "More than 50000")
    public string MonthlyIncome { get; set; }
    
    // Number of family members (integer value)
    public int FamilySize { get; set; }
}