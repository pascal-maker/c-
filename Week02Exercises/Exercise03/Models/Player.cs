using System;
namespace Ct.Ai.Models
{
    public class Player
    {
        public void PlaySong(Song song)
        {
            Console.WriteLine($"Playing song: {song.Title}");
        }


        public void Play(Album album)
        {
            foreach (Song song in album.Songs)
            {
                PlaySong(song);
            }
        }

        public void Play(List<Song> songs)
        {
            foreach (Song song in songs)
            {
                PlaySong(song);
            }
        }


    }

}