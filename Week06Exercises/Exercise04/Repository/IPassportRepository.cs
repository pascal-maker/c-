using Exercise04.Models;
namespace Exercise04.Repositories
{
    public interface IPassportRepository
    {
        void AddPassport(int travelerId, string passportNumber);
        List<Passport> GetAllPassports();
        Passport GetById(int id);
        Passport GetPassportByTravelerId(int travelerId);
        void UpdatePassport(int travelerId, string newPassportNumber);
        void RemovePassport(int travelerId);
    }
}
