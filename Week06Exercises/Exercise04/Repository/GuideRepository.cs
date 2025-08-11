using Exercise04.Data;
using Exercise04.Models;
using Microsoft.EntityFrameworkCore;


namespace Exercise04.Repositories
{
    public class GuideRepository : IGuideRepository
    {
        private readonly AppDbContext _context;

        public GuideRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddGuide(Guide guide)
        {
            _context.Guide.Add(guide);
            _context.SaveChanges();
        }


        public List<Guide> GetAllGuides()
        {
            return _context.Guide.Include(g => g.Tours).ToList();
        }


        public Guide  GetGuideById(int id)
        {
            return _context.Guide.Include(g => g.Tours).FirstOrDefault(g => g.Id == id);
        }








    }
}