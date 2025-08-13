using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;


namespace Exercise04.Repositories
{
    public class PassportRepository : IPassportRepository
    {
        private readonly AppDbContext _context;

        public PassportRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPassport(int travelerId, string passportNumber)
        {
            var traveler = _context.Travellers.FirstOrDefault(t => t.Id == travelerId);
           

            var passport = new Passport
            {
                PassportNumber = passportNumber,
                Traveler = traveler
            };
            _context.Passport.Add(passport);
            _context.SaveChanges();
        }

        public List<Passport> GetAllPassports()
        {
            return _context.Passport.ToList();
        }

        public Passport GetById(int id)
        {
            return _context.Passport.FirstOrDefault(p => p.Id == id);
        }

        public Passport GetPassportByTravelerId(int travelerId)
        {
            return _context.Passport.FirstOrDefault(p => p.Traveler.Id == travelerId);
        }

        public void UpdatePassport(int travelerId, string newPassportNumber)
        {
            var passport = _context.Passport.FirstOrDefault(p => p.Traveler.Id == travelerId);
            passport.PassportNumber = newPassportNumber;
            _context.SaveChanges();
        }

        public void RemovePassport(int travelerId)
        {
            var passport = _context.Passport.FirstOrDefault(p => p.Traveler.Id == travelerId);
            _context.Passport.Remove(passport);
            _context.SaveChanges();
        }
    }
}       