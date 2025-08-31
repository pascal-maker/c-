namespace library.models
{
    /// <summary>
    /// Subklasse Book erft van LibraryItem.
    /// Bevat extra eigenschap: Author (auteur).
    /// </summary>
    public class Book : LibraryItem
    {
        public string Author { get; set; }

        // Constructor → roept de base constructor aan om ID, Title, Year in te stellen
        public Book(int id, string title, int yearpublished, string author)
            : base(id, title, yearpublished)
        {
            Author = author;
        }

        // Override → toont details van een Book inclusief auteur
        public override void PrintDetails()
        {
            Console.WriteLine($"ID: {ID}, Title: {Title}, Year: {YearPublished}, Author: {Author}");
        }
    }
}
