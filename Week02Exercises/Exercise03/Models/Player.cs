namespace music.Models
{
    // Klasse die verantwoordelijk is voor het "afspelen" van een song.
    // In dit eenvoudige voorbeeld betekent dat: info naar de console schrijven.
    public class Player
    {
        // Methode die een Song ontvangt en de titel + duur toont.
        // Parameter:
        //   song - het liedje dat we willen afspelen/tonen.
        public void PlaySong(Song song)
        {
            // Schrijf een bericht naar de console met de titel en duur van de song.
            // Let op: dit gaat ervan uit dat 'song' niet null is en dat de properties bestaan.
            //vergeet neit als je zo een methde creert als je void gebrukt dan moet je ook een body hebben het moet iets declareren.
            Console.WriteLine($" Playing song Title: {song.Title} and duration: {song.Duration}");
        }
    }
}
