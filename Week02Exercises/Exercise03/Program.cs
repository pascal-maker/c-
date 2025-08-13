namespace Ct.Ai.Models;
using System.Collections.Generic;

class Exercise03
{
    static void Main(string[] args)
    {
        Song song1 = new Song
        {
            Title = "kaka",
            Duration = 5
        };

        Song song2 = new Song
        {
            Title = "Degrassi",
            Duration = 5
        };

        Song song3 = new Song
        {
            Title = "Yes",
            Duration = 5
        };


        List<Song> songs = new List<Song>
        {
            song1,
            song2,
            song3
        };

        Album album = new Album ("nothing was the same", "Drake", "Hiphop", 2020, songs);

        Player player = new Player();
        player.PlaySong(song1);
        player.PlaySong(song2);
        player.PlaySong(song3);
    }
}


