using music.Models;
using System.Collections.Generic;

// Maak eerst song-objecten aan (elke song heeft een titel en een duur in minuten)
Song b1 = new Song("Graduation", 4);
Song b2 = new Song("Heartless", 3);

// Maak album-objecten aan en voeg de songs toe via een List<Song>
Album a1 = new Album("My Beautiful Dark Twisted Fantasy", "Kanye West", "HipHop", "2010", new List<Song> { b1, b2 });

// Maak een player-object aan (de "muziekspeler")
Player player = new Player();

// Speel een individueel nummer af
player.PlaySong(b2);

// Speel een volledig album af
player.PlayAlbum(a1);
