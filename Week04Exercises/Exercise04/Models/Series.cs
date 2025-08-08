using Ct.Ai.Models;

namespace Ct.Ai.Models
{
    public class Series :  IMedia
    {
        public string Title { get; set; }
        public int NumberOfEpisodes {get; set; }
        public string Genre { get; set; }
        public string   Creator{ get; set; }

        public Series(string title, int numberofepisodes, string genre, string creator)
        {
            
            Title = title;
            NumberOfEpisodes = numberofepisodes;
            Genre = genre;
            Creator = creator;
        }
        

        public void Consume()
        {
            // Eventueel extra logica, maar hier volstaat:
            Console.WriteLine($"Binging serie: {Title},NumberOfEspisodes {NumberOfEpisodes}");
        }


        public override string ToString()
        {
            return $"Title: {Title}, Number Of Episodes {NumberOfEpisodes}, Genre: {Genre}, Creator: {Creator}";
        }
    }
}