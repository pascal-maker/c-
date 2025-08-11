using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise04.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AppDbContext _context;

        public DestinationRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddDestination(Destination destination)
        {
            _context.Destinations.Add(destination);
            _context.SaveChanges();
        }

        public List<Destination> GetAllDestinations()
        {
            return _context.Destinations.Include(d => d.Travelers).ToList();
        }


        public Destination  GetDestinationByID(int id)
        {
            return _context.Destinations.Include(d => d.Travelers).FirstOrDefault(d => d.Id == id);
        }
    }
}
