// Import CsvHelper configuration namespace for ClassMap functionality
using CsvHelper.Configuration;
// Import CsvHelper type conversion namespace for boolean value conversion
using CsvHelper.TypeConversion;
// Import Google.Protobuf.Collections namespace (not strictly needed for CSV mapping)
using Google.Protobuf.Collections;

// Define the namespace for survey models
namespace survey.Models;

// Mapping class that defines how CSV columns map to SurveyResponses properties
// This class inherits from ClassMap<SurveyResponses> to provide mapping functionality
public class SurveyReponsesMap : ClassMap<SurveyResponses>
{
    // Constructor that sets up all the mappings between CSV columns and C# properties
    public SurveyReponsesMap()
    {
        // Map the Age property to the "Age" column in the CSV file
        Map(m => m.Age).Name("Age");
        // Map the Gender property to the "Gender" column in the CSV file
        Map(m => m.Gender).Name("Gender");
        // Map the MaritalStatus property to the "Marital Status" column (note the space in CSV)
        Map(m => m.MaritalStatus).Name("Marital Status");
        // Map the Occupation property to the "Occupation" column in the CSV file
        Map(m => m.Occupation).Name("Occupation");
        // Map the MonthlyIncome property to the "Monthly Income" column (note the space in CSV)
        Map(m => m.MonthlyIncome).Name("Monthly Income");
        // Map the EducationQualifications property to the "Educational Qualifications" column (note the space and different name)
        Map(m => m.EducationalQualifications).Name("Educational Qualifications");
        // Map the FamilySize property to the "Family size" column (note the space and lowercase in CSV)
        Map(m => m.FamilySize).Name("Family size");
        // Map the Latitude property to the "latitude" column (note the lowercase in CSV)
        Map(m => m.Latitude).Name("latitude");
        // Map the Longtitude property to the "longitude" column (note the lowercase in CSV)
        Map(m => m.Longitude).Name("longitude");
        // Map the Pincode property to the "Pin code" column (note the space in CSV)
        Map(m => m.PinCode).Name("Pin code");

        // Map the Output property (boolean) to the "Output" column with special type conversion
        Map(m => m.Output)
            // Specify the CSV column name as "Output"
            .Name("Output")
            // Configure type conversion: convert "Yes" string to true boolean value
            .TypeConverterOption.BooleanValues(true, true, "Yes")
            // Configure type conversion: convert "No" string to false boolean value
            .TypeConverterOption.BooleanValues(false, true, "No");

        // Map the Feedback property to the "Feedback" column in the CSV file
        Map(m => m.Feedback).Name("Feedback");  

        // Empty lines for code readability and formatting
        














    }
}