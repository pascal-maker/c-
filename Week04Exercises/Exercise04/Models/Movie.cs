using Ct.Ai.Models;

namespace Ct.Ai.Models
{
    public class Movie : IMedia
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

        public Movie(string title, int duration, string genre, string director)
        {

            Title = title;
            Duration = duration;
            Genre = genre;
            Director = director;
        }

         public void Consume()
        {
            // Eventueel extra logica, maar hier volstaat:
            Console.WriteLine($"Playing movie: {Title},Minutes {Duration}");
        }

        public override string ToString()
        {
            return $"Title: {Title}, Duration: {Duration}, Genre: {Genre}, Director: {Director}";
        }
        
        
    }
}
