// Import required namespaces for CSV handling and database operations
using survey.Models;  // Import the SurveyResponses model class
using MySql.Data.MySqlClient;  // Import MySQL database client for database operations
using System.Globalization;  // Import culture information for CSV parsing
using CsvHelper;  // Import CSV helper library for reading CSV files
using CsvHelper.Configuration;  // Import CSV configuration for custom settings

// Define the namespace for survey repositories
namespace survey.Repositories;

// Implementation of ISurveyRepository that handles database operations for SurveyResponses
public class SurveyRepository : ISurveyRepository
{
    // Connection string for MySQL database with server, database name, user, password and SSL settings
    private const string _connectionString = "server=localhost;database=Exercise02;user=root;password=9370;SslMode=None;AllowPublicKeyRetrieval=True;";
     
    // Method to import CSV data into the database
    public void ImportCSVToDatabase(string filePath)
    {
        // Clear all existing data from both tables before importing new data
        ClearAllData();

        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();

            // Create a StreamReader to read the CSV file
            using (var reader = new StreamReader(filePath))
            // Create a CsvReader with specific configuration for parsing CSV data
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,  // Indicate that the CSV file has a header row
                MissingFieldFound = null  // Ignore missing fields in the CSV
            }))
            {
                // Register the mapping class for proper CSV to object conversion
                csv.Context.RegisterClassMap<SurveyReponsesMap>();
                // Read all records from the CSV file and convert them to SurveyResponses objects
                var records = csv.GetRecords<SurveyResponses>();

                // Loop through each survey response record from the CSV
                foreach (var record in records)
                {
                    // Create a SQL INSERT command to insert survey response data into the database
                    var command = new MySqlCommand(@"INSERT INTO SurveyResponses (Age, Gender, MaritalStatus, Occupation, MonthlyIncome, EducationalQualifications, FamilySize, Latitude, Longitude, PinCode, Output, Feedback) 
                            VALUES(@Age, @Gender, @MaritalStatus, @Occupation, @MonthlyIncome, @EducationalQualifications, @FamilySize, @Latitude, @Longitude, @PinCode, @Output, @Feedback)", connection);

                    // Add parameter for Age with the record's age value
                    command.Parameters.AddWithValue("@Age", record.Age);
                    // Add parameter for Gender with the record's gender value
                    command.Parameters.AddWithValue("@Gender", record.Gender);
                    // Add parameter for MaritalStatus with the record's marital status value
                    command.Parameters.AddWithValue("@MaritalStatus", record.MaritalStatus);
                    // Add parameter for Occupation with the record's occupation value
                    command.Parameters.AddWithValue("@Occupation", record.Occupation);
                    // Add parameter for MonthlyIncome with the record's monthly income value
                    command.Parameters.AddWithValue("@MonthlyIncome", record.MonthlyIncome);
                    // Add parameter for EducationalQualifications with the record's education value
                    command.Parameters.AddWithValue("@EducationalQualifications", record.EducationalQualifications);
                    // Add parameter for FamilySize with the record's family size value
                    command.Parameters.AddWithValue("@FamilySize", record.FamilySize);
                    // Add parameter for Latitude with the record's latitude value
                    command.Parameters.AddWithValue("@Latitude", record.Latitude);
                    // Add parameter for Longitude with the record's longitude value
                    command.Parameters.AddWithValue("@Longitude", record.Longitude);
                    // Add parameter for PinCode with the record's pin code value
                    command.Parameters.AddWithValue("@PinCode", record.PinCode);
                    // Add parameter for Output with the record's output value (boolean)
                    command.Parameters.AddWithValue("@Output", record.Output);
                    // Add parameter for Feedback with the record's feedback value
                    command.Parameters.AddWithValue("@Feedback", record.Feedback);
                    
                    // Execute the INSERT command to save the record to the database
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    // Method to get all survey responses from the database
    public List<SurveyResponses> GetAllSurveyResponses()
    {
        // Create a new list to store all survey responses
        var responses = new List<SurveyResponses>();
        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();
            // Create a SQL SELECT command to retrieve all survey responses
            var command = new MySqlCommand("SELECT * FROM SurveyResponses", connection);
            // Execute the command and get a data reader
            var reader = command.ExecuteReader();
            // Loop through each row in the result set
            while (reader.Read())
            {
                // Create a new SurveyResponses object and populate it with data from the current row
                responses.Add(new SurveyResponses
                {
                    // Get the Id column as integer from the database
                    Id = reader.GetInt32("Id"),
                    // Get the Age column as integer from the database
                    Age = reader.GetInt32("Age"),
                    // Get the Gender column as string from the database
                    Gender = reader.GetString("Gender"),
                    // Get the MaritalStatus column as string from the database
                    MaritalStatus = reader.GetString("MaritalStatus"),
                    // Get the Occupation column as string from the database
                    Occupation = reader.GetString("Occupation"),
                    // Get the MonthlyIncome column as string from the database
                    MonthlyIncome = reader.GetString("MonthlyIncome"),
                    // Get the EducationalQualifications column as string from the database
                    EducationalQualifications = reader.GetString("EducationalQualifications"),
                    // Get the FamilySize column as integer from the database
                    FamilySize = reader.GetInt32("FamilySize"),
                    // Get the Latitude column as double from the database
                    Latitude = reader.GetDouble("Latitude"),
                    // Get the Longitude column as double from the database
                    Longitude = reader.GetDouble("Longitude"),
                    // Get the PinCode column as string from the database
                    PinCode = reader.GetString("PinCode"),
                    // Get the Output column as boolean from the database
                    Output = reader.GetBoolean("Output"),
                    // Get the Feedback column as string from the database
                    Feedback = reader.GetString("Feedback")
                });
            }
        }
        // Return the list of all survey responses
        return responses;
    }

    // Method to count feedbacks by specific feedback type
    public int CountFeedbacksByType(string feedbackType)
    {
        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();
            // Create a SQL COUNT command to count feedbacks of the specified type
            var command = new MySqlCommand("SELECT COUNT(*) FROM SurveyResponses WHERE Feedback = @FeedbackType", connection);
            // Add parameter for the feedback type to prevent SQL injection
            command.Parameters.AddWithValue("@FeedbackType", feedbackType);
            // Execute the command and convert the result to integer
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }

    // Method to calculate average age of all survey responses
    public double GetAverageAge()
    {
        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();
            // Create a SQL AVG command to calculate the average age
            var command = new MySqlCommand("SELECT AVG(Age) FROM SurveyResponses", connection);
            // Execute the command and get the result
            var result = command.ExecuteScalar();
            // Check if the result is null and return 0 if it is, otherwise convert to double
            return result == DBNull.Value ? 0 : Convert.ToDouble(result);
        }
    }

    // Method to get all unique occupation types
    public List<string> GetAllOccupationTypes()
    {
        // Create a new list to store occupation types
        var occupations = new List<string>();
        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();
            // Create a SQL DISTINCT command to get unique occupation types, ordered alphabetically
            var command = new MySqlCommand("SELECT DISTINCT Occupation FROM SurveyResponses ORDER BY Occupation", connection);
            // Execute the command and get a data reader
            var reader = command.ExecuteReader();
            
            // Loop through each row in the result set
            while (reader.Read())
            {
                // Add each occupation type to the list
                occupations.Add(reader.GetString("Occupation"));
            }
        }
        // Return the list of all unique occupation types
        return occupations;
    }

    // Method to get survey responses by family size
    public List<SurveyResponses> GetResponsesByFamilySize(int familySize)
    {
        // Create a new list to store survey responses
        var responses = new List<SurveyResponses>();
        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();
            // Create a SQL SELECT command to get responses with the specified family size
            var command = new MySqlCommand("SELECT * FROM SurveyResponses WHERE FamilySize = @FamilySize", connection);
            // Add parameter for the family size to prevent SQL injection
            command.Parameters.AddWithValue("@FamilySize", familySize);
            // Execute the command and get a data reader
            var reader = command.ExecuteReader();
            
            // Loop through each row in the result set
            while (reader.Read())
            {
                // Create a new SurveyResponses object and populate it with data from the current row
                responses.Add(new SurveyResponses
                {
                    // Get the Id column as integer from the database
                    Id = reader.GetInt32("Id"),
                    // Get the Age column as integer from the database
                    Age = reader.GetInt32("Age"),
                    // Get the Gender column as string from the database
                    Gender = reader.GetString("Gender"),
                    // Get the MaritalStatus column as string from the database
                    MaritalStatus = reader.GetString("MaritalStatus"),
                    // Get the Occupation column as string from the database
                    Occupation = reader.GetString("Occupation"),
                    // Get the MonthlyIncome column as string from the database
                    MonthlyIncome = reader.GetString("MonthlyIncome"),
                    // Get the EducationalQualifications column as string from the database
                    EducationalQualifications = reader.GetString("EducationalQualifications"),
                    // Get the FamilySize column as integer from the database
                    FamilySize = reader.GetInt32("FamilySize"),
                    // Get the Latitude column as double from the database
                    Latitude = reader.GetDouble("Latitude"),
                    // Get the Longitude column as double from the database
                    Longitude = reader.GetDouble("Longitude"),
                    // Get the PinCode column as string from the database
                    PinCode = reader.GetString("PinCode"),
                    // Get the Output column as boolean from the database
                    Output = reader.GetBoolean("Output"),
                    // Get the Feedback column as string from the database
                    Feedback = reader.GetString("Feedback")
                });
            }
        }
        // Return the list of survey responses with the specified family size
        return responses;
    }

    // Method to export survey responses to AI train data format
    public void ExportToAITRainData()
    {
        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();
            
            // Clear existing AI train data by deleting all records from AITrainData table
            var clearCommand = new MySqlCommand("DELETE FROM AITrainData", connection);
            clearCommand.ExecuteNonQuery();
            
            // Insert data from SurveyResponses to AITrainData using a SELECT INTO statement
            var command = new MySqlCommand(@"
                INSERT INTO AITrainData (Age, Gender, MaritalStatus, Occupation, MonthlyIncome, FamilySize)
                SELECT Age, Gender, MaritalStatus, Occupation, MonthlyIncome, FamilySize
                FROM SurveyResponses", connection);
            
            // Execute the command to copy data to AI train data format
            command.ExecuteNonQuery();
        }
    }

    // Method to clear all data from both tables
    public void ClearAllData()
    {
        // Create a new MySQL connection using the connection string
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Open the database connection
            connection.Open();
            // Delete all records from the SurveyResponses table
            var command1 = new MySqlCommand("DELETE FROM SurveyResponses", connection);
            command1.ExecuteNonQuery();
            
            // Delete all records from the AITrainData table
            var command2 = new MySqlCommand("DELETE FROM AITrainData", connection);
            command2.ExecuteNonQuery();
        }
    }
}