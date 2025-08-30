namespace music.Models
{
    public class Album
    {
        // Eigenschappen van een album
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }

        // Een album kan meerdere songs bevatten
        public List<Song> Songs { get; set; }

        // Constructor → vult alle eigenschappen in bij het maken van een Album-object
        public Album(string name, string artist, string genre, string year, List<Song> songs)
        {
            Name = name;
            Artist = artist;
            Genre = genre;
            Year = year;
            Songs = songs;
        }
    }
}
