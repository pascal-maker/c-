namespace library.models                 // Namespace waarin de Book-klasse zich bevindt
{
    // De Book-klasse erft van de LibraryItem-klasse (Book is een type LibraryItem)
    public class Book : LibraryItem
    {
        // Eigenschap (property) voor de auteur van het boek
        public string Author { get; set; }

        // Constructor voor Book
        // Parameters:
        //   id             -> Unieke identificatie van het boek
        //   title          -> Titel van het boek
        //   yearpublished  -> Publicatiejaar van het boek
        //   author         -> Naam van de auteur
        // De constructor roept de base-constructor van LibraryItem aan om ID, Title en YearPublished in te stellen
        public Book(int id, string title, int yearpublished, string author) : base(id, title, yearpublished)
        {
            Author = author; // Stel de eigenschap Author in met de waarde uit de parameter
        }

        // Override van de virtuele methode PrintDetails() uit de LibraryItem-klasse
        // Dit zorgt ervoor dat Book zijn eigen details kan printen, inclusief de auteur
        public override void PrintDetails()
        {
            Console.WriteLine($"ID: {ID} Title: {Title}, Year: {YearPublished}, Author: {Author}");
        }
    }
}
