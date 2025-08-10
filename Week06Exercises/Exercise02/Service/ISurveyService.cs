using Exercise02.Models;

namespace Exercise02.Service
{
    public interface ISurveyService
    {
        void ImportCSVToDatabase(string filePath);
        List<SurveyResponse> GetAllSurveyResponses();
        int CountFeedbacksByType(string feedbackType);
        double GetAverageAge();
        List<string> GetAllOccupationTypes();
        List<SurveyResponse> GetResponsesByFamilySize(int familySize);
        void ExportToAITrainData();
        void ExportToCSV(List<SurveyResponse> responses, string fileName);
    }
} 