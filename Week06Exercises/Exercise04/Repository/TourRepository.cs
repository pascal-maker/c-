using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;


namespace Exercise04.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext _context;

        public TourRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTour(Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }


        public List<Tour> GetAllTours()
        {
            return _context.Tours.Include(t => t.Guide).ToList();
        }


        public Tour  GetTourById(int id)
        {
            return _context.Tours.Include(t => t.Guide).FirstOrDefault(t => t.Id == id);
        }








    }
}