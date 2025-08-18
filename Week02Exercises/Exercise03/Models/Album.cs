namespace music.Models
{
    public class Album
    {
        public string Name { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }
        
        public string Year { get; set; }

        public List<Song> Songs { get; set; }


        public Album(string name, string artist, string genre, string year, List<Song > songs)
        {
            Name = name;
            Artist = artist;
            Genre = genre;
            Year = year;
            Songs = songs;
            
        }


   
    }

}