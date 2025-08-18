namespace music.Models
{
    public class Song
    {
        public string Title { get; set; }

        public int Duration { get; set; }


        public Song(string title, int duration)
        {
            Title = title;
            Duration = duration;
        }



    }

}