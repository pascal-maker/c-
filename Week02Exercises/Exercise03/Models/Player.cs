using System;
using System.Collections.Generic;

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

        // Methode om een volledig album af te spelen
        public void PlayAlbum(Album album)
        {
            Console.WriteLine($"Playing album: {album.Name} by {album.Artist}");
            
            foreach (var song in album.Songs)
            {
                PlaySong(song);
            }
        }
    }
}
