namespace music.Models
{
    // Klasse die verantwoordelijk is voor het "afspelen" van een song.
    public class Player
    {
        // Methode om een liedje af te spelen.
        // Hier betekent "afspelen": informatie tonen op de console.
        public void PlaySong(Song song)
        {
            // Met string interpolatie tonen we de titel en de duur van het liedje.
            Console.WriteLine($"Playing song: {song.Title}, Duration: {song.Duration} min");
        }
    }
}
