using Exercise04.Models;
namespace Exercise04.Services
{
    public interface IPassportService
    {
        void AssignPassport(int travelerId, string passportNumber);
        Passport GetPassportByTravelerId(int travelerId);
        void UpdatePassport(int travelerId, string newPassportNumber);
        void RemovePassport(int travelerId);
        List<Passport> GetAllPassports();
    }
}

