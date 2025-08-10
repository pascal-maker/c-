using Exercise02.Repository;
using Exercise02.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Exercise02.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repository;

        public SurveyService(ISurveyRepository repository)
        {
            _repository = repository;
        }

        public void ImportCSVToDatabase(string filePath)
        {
            _repository.ImportCSVToDatabase(filePath);
        }

        public List<SurveyResponse> GetAllSurveyResponses()
        {
            return _repository.GetAllSurveyResponses();
        }

        public int CountFeedbacksByType(string feedbackType)
        {
            return _repository.CountFeedbacksByType(feedbackType);
        }

        public double GetAverageAge()
        {
            return _repository.GetAverageAge();
        }

        public List<string> GetAllOccupationTypes()
        {
            return _repository.GetAllOccupationTypes();
        }

        public List<SurveyResponse> GetResponsesByFamilySize(int familySize)
        {
            return _repository.GetResponsesByFamilySize(familySize);
        }

        public void ExportToAITrainData()
        {
            _repository.ExportToAITrainData();
        }

        public void ExportToCSV(List<SurveyResponse> responses, string fileName)
        {
            // ✅ Use CsvHelper for clean CSV export
            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            }))
            {
                // Register the mapping for consistent formatting
                csv.Context.RegisterClassMap<SurveyResponseMap>();
                
                // Write all records
                csv.WriteRecords(responses);
            }
        }
    }
} 