namespace music.Models
{
    public class Song
    {
        // Eigenschappen van een song
        public string Title { get; set; }
        public int Duration { get; set; }

        // Constructor → vult de titel en duur in bij het maken van een Song-object
        public Song(string title, int duration)
        {
            Title = title;
            Duration = duration;
        }
    }
}
