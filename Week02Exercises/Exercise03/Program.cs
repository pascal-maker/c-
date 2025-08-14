using System.Net.Http.Headers;
using music.Models;
//creer object song
Song b2 = new Song("heartless", 3);
Song b1 = new Song("graduation", 4);
//creer object album
Album a1 = new Album("mybeautifuldarktwistefantasy", "kanyewest", "hiphop", "2010", new List<Song> { b1 });
Album a2 = new Album ("mybeautifuldarktwistefantasy", "kanyewest", "hiphop", "2010", new List<Song> { b1,b2 });
//creer object album
//je moet een object van player creeren player heeft namelijk als parametrs songs ipv van die in te vullen  gebruik je player roep je Playsong aan vul je b2 je songs in 
Player player = new Player();
player.PlaySong(b2);