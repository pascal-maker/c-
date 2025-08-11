using Exercise04.Models;
using Exercise04.Repositories;

namespace Exercise04.Services
{
    public class PassportService : IPassportService
    {
        private readonly IPassportRepository _passportRepo;
        private readonly ITravelRepository _travelerRepo;

        public PassportService(IPassportRepository passportRepo, ITravelRepository travelerRepo)
        {
            _passportRepo = passportRepo;
            _travelerRepo = travelerRepo;
        }

        public void AssignPassport(int travelerId, string passportNumber)
        {
            // Validate that traveler exists
            var traveler = _travelerRepo.GetTravelerById(travelerId);
            if (traveler == null)
                throw new ArgumentException($"Traveler with ID {travelerId} not found");

            // Check if passport number is valid
            if (string.IsNullOrWhiteSpace(passportNumber))
                throw new ArgumentException("Passport number cannot be empty");

            _passportRepo.AddPassport(travelerId, passportNumber);
        }

        public Passport GetPassportByTravelerId(int travelerId)
        {
            return _passportRepo.GetPassportByTravelerId(travelerId);
        }

        public void UpdatePassport(int travelerId, string newPassportNumber)
        {
            if (string.IsNullOrWhiteSpace(newPassportNumber))
                throw new ArgumentException("Passport number cannot be empty");

            _passportRepo.UpdatePassport(travelerId, newPassportNumber);
        }

        public void RemovePassport(int travelerId)
        {
            _passportRepo.RemovePassport(travelerId);
        }

        public List<Passport> GetAllPassports()
        {
            return _passportRepo.GetAllPassports();
        }
    }
}
