namespace library.models                 // Namespace waarin de LibraryItem-klasse zich bevindt
{
    // Basisklasse (superclass) voor alle bibliotheekitems zoals boeken, dvd's, etc.
    public class LibraryItem
    {
        // Eigenschap voor het unieke ID van het bibliotheekitem
        public int ID { get; set; }

        // Eigenschap voor de titel van het item
        public string Title { get; set; }

        // Eigenschap voor het publicatiejaar van het item
        public int YearPublished { get; set; }

        // Constructor voor LibraryItem
        // Parameters:
        //   id             -> Unieke identificatie van het item
        //   title          -> Titel van het item
        //   yearpublished  -> Jaar waarin het item is gepubliceerd
        public LibraryItem(int id, string title, int yearpublished)
        {
            ID = id;                       // Zet het ID
            Title = title;                 // Zet de titel
            YearPublished = yearpublished; // Zet het publicatiejaar
        }

        // Virtuele methode om de details van het item te printen.
        // 'virtual' betekent dat afgeleide klassen (zoals Book of DVD)
        // deze methode kunnen overschrijven (override) om extra details toe te voegen.
        public virtual void PrintDetails()
        {
            Console.WriteLine($"ID: {ID} Title: {Title}, Year: {YearPublished}");
        }
    }
}
