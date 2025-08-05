using System;
namespace Ct.Ai.Models

{
    public class Album
    {
        public string Name { get; set; }
        public string Artist { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }




        public List<Song> Songs = new List<Song>();

        public Album(string name, string artist, string genre, int year, List<Song> songs)
        {
         Name = name;
         Artist = artist;
         Genre = genre;
         Year = year;
         Songs = songs;
        }

    }    
         
         
         
        

       


        



        
}
