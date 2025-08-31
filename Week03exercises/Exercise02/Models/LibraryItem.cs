using System;

namespace library.models
{
    /// <summary>
    /// Basisklasse voor alle bibliotheekitems (boeken, dvd's, magazines, ...)
    /// Deze class bevat gemeenschappelijke eigenschappen en methodes.
    /// </summary>
    public class LibraryItem
    {
        // Uniek ID van het item
        public int ID { get; set; }

        // Titel van het item
        public string Title { get; set; }

        // Jaar van publicatie
        public int YearPublished { get; set; }

        // Constructor → elke LibraryItem moet ID, Titel en Jaar hebben
        public LibraryItem(int id, string title, int yearpublished)
        {
            ID = id;
            Title = title;
            YearPublished = yearpublished;
        }

        /// <summary>
        /// Virtuele methode → kan overschreven worden in subklassen.
        /// Standaard geeft hij basisinformatie van een item weer.
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.WriteLine($"ID: {ID}, Title: {Title}, Year: {YearPublished}");
        }
    }
}
