using MySql.Data.MySqlClient;
using Exercise02.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Exercise02.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private const string _connectionString = "server=localhost;database=Exercise02;user=root;password=9370;SslMode=None;AllowPublicKeyRetrieval=True";

        public void ImportCSVToDatabase(string filePath)
        {
            ClearAllData(); // Clear existing data before import

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                
                // ✅ Use CsvHelper for clean CSV processing
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    MissingFieldFound = null
                }))
                {
                    // Register the mapping
                    csv.Context.RegisterClassMap<SurveyResponseMap>();
                    
                    // Read all records
                    var records = csv.GetRecords<SurveyResponse>();
                    
                    foreach (var record in records)
                    {
                        var command = new MySqlCommand(@"
                            INSERT INTO SurveyResponses (Age, Gender, MaritalStatus, Occupation, MonthlyIncome, 
                                                       EducationalQualifications, FamilySize, Latitude, Longitude, 
                                                       PinCode, Output, Feedback) 
                            VALUES (@Age, @Gender, @MaritalStatus, @Occupation, @MonthlyIncome, 
                                    @EducationalQualifications, @FamilySize, @Latitude, @Longitude, 
                                    @PinCode, @Output, @Feedback)", connection);
                        
                        command.Parameters.AddWithValue("@Age", record.Age);
                        command.Parameters.AddWithValue("@Gender", record.Gender);
                        command.Parameters.AddWithValue("@MaritalStatus", record.MaritalStatus);
                        command.Parameters.AddWithValue("@Occupation", record.Occupation);
                        command.Parameters.AddWithValue("@MonthlyIncome", record.MonthlyIncome);
                        command.Parameters.AddWithValue("@EducationalQualifications", record.EducationalQualifications);
                        command.Parameters.AddWithValue("@FamilySize", record.FamilySize);
                        command.Parameters.AddWithValue("@Latitude", record.Latitude);
                        command.Parameters.AddWithValue("@Longitude", record.Longitude);
                        command.Parameters.AddWithValue("@PinCode", record.PinCode);
                        command.Parameters.AddWithValue("@Output", record.Output);
                        command.Parameters.AddWithValue("@Feedback", record.Feedback);
                        
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<SurveyResponse> GetAllSurveyResponses()
        {
            var responses = new List<SurveyResponse>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM SurveyResponses", connection);
                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    responses.Add(new SurveyResponse
                    {
                        Id = reader.GetInt32("Id"),
                        Age = reader.GetInt32("Age"),
                        Gender = reader.GetString("Gender"),
                        MaritalStatus = reader.GetString("MaritalStatus"),
                        Occupation = reader.GetString("Occupation"),
                        MonthlyIncome = reader.GetString("MonthlyIncome"),
                        EducationalQualifications = reader.GetString("EducationalQualifications"),
                        FamilySize = reader.GetInt32("FamilySize"),
                        Latitude = reader.GetDouble("Latitude"),
                        Longitude = reader.GetDouble("Longitude"),
                        PinCode = reader.GetString("PinCode"),
                        Output = reader.GetBoolean("Output"),
                        Feedback = reader.GetString("Feedback")
                    });
                }
            }
            return responses;
        }

        public int CountFeedbacksByType(string feedbackType)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT COUNT(*) FROM SurveyResponses WHERE Feedback = @FeedbackType", connection);
                command.Parameters.AddWithValue("@FeedbackType", feedbackType);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public double GetAverageAge()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT AVG(Age) FROM SurveyResponses", connection);
                var result = command.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToDouble(result);
            }
        }

        public List<string> GetAllOccupationTypes()
        {
            var occupations = new List<string>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT DISTINCT Occupation FROM SurveyResponses ORDER BY Occupation", connection);
                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    occupations.Add(reader.GetString("Occupation"));
                }
            }
            return occupations;
        }

        public List<SurveyResponse> GetResponsesByFamilySize(int familySize)
        {
            var responses = new List<SurveyResponse>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM SurveyResponses WHERE FamilySize = @FamilySize", connection);
                command.Parameters.AddWithValue("@FamilySize", familySize);
                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    responses.Add(new SurveyResponse
                    {
                        Id = reader.GetInt32("Id"),
                        Age = reader.GetInt32("Age"),
                        Gender = reader.GetString("Gender"),
                        MaritalStatus = reader.GetString("MaritalStatus"),
                        Occupation = reader.GetString("Occupation"),
                        MonthlyIncome = reader.GetString("MonthlyIncome"),
                        EducationalQualifications = reader.GetString("EducationalQualifications"),
                        FamilySize = reader.GetInt32("FamilySize"),
                        Latitude = reader.GetDouble("Latitude"),
                        Longitude = reader.GetDouble("Longitude"),
                        PinCode = reader.GetString("PinCode"),
                        Output = reader.GetBoolean("Output"),
                        Feedback = reader.GetString("Feedback")
                    });
                }
            }
            return responses;
        }

        public void ExportToAITrainData()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                
                // Clear existing AI train data
                var clearCommand = new MySqlCommand("DELETE FROM AITrainData", connection);
                clearCommand.ExecuteNonQuery();
                
                // Insert data from SurveyResponses to AITrainData
                var command = new MySqlCommand(@"
                    INSERT INTO AITrainData (Age, Gender, MaritalStatus, Occupation, MonthlyIncome, FamilySize)
                    SELECT Age, Gender, MaritalStatus, Occupation, MonthlyIncome, FamilySize
                    FROM SurveyResponses", connection);
                
                command.ExecuteNonQuery();
            }
        }

        public void ClearAllData()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM SurveyResponses", connection);
                command.ExecuteNonQuery();
            }
        }
    }
} 