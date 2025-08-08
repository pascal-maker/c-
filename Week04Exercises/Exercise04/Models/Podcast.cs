using Ct.Ai.Models;

namespace Ct.Ai.Models
{
    public class Podcast : IMedia
    {
        public string Title { get; set; }
        public int NumberOfEpisodes {get; set; }
        public string Host { get; set; }
        

        public Podcast(string title, int numberofepisodes, string host)
        {
            
            Title = title;
            NumberOfEpisodes = numberofepisodes;
            Host = host;
        }
        

        public void Consume()
        {
            // Eventueel extra logica, maar hier volstaat:
            Console.WriteLine($"Playing podcast: {Title}, Host {Host}");
        }


        public override string ToString()
        {
            return $"Title: {Title}, Number Of Episodes {NumberOfEpisodes}, Host: {Host}";
        }
    }
}