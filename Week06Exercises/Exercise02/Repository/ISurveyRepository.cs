using Exercise02.Models;

namespace Exercise02.Repository
{
    public interface ISurveyRepository
    {
        void ImportCSVToDatabase(string filePath);
        List<SurveyResponse> GetAllSurveyResponses();
        int CountFeedbacksByType(string feedbackType);
        double GetAverageAge();
        List<string> GetAllOccupationTypes();
        List<SurveyResponse> GetResponsesByFamilySize(int familySize);
        void ExportToAITrainData();
        void ClearAllData();
    }
} 