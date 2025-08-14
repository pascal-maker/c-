namespace library.models                 // Namespace waarin de DVD-klasse zich bevindt
{
    // De DVD-klasse erft van de LibraryItem-klasse (DVD is een type LibraryItem)
    public class DVD : LibraryItem
    {
        // Eigenschap (property) voor de duur van de DVD in minuten
        public int Duration { get; set; }

        // Constructor voor DVD
        // Parameters:
        //   id             -> Unieke identificatie van de DVD
        //   title          -> Titel van de DVD
        //   yearpublished  -> Publicatiejaar van de DVD
        //   duration       -> Speelduur van de DVD in minuten
        // De constructor roept de base-constructor van LibraryItem aan om ID, Title en YearPublished in te stellen
        public DVD(int id, string title, int yearpublished, int duration) : base(id, title, yearpublished)
        {
            Duration = duration; // Stel de eigenschap Duration in met de waarde uit de parameter
        }

        // Override van de virtuele methode PrintDetails() uit de LibraryItem-klasse
        // Dit zorgt ervoor dat DVD zijn eigen details kan printen, inclusief de speelduur
        public override void PrintDetails()
        {
            Console.WriteLine($"ID: {ID} Title: {Title}, Year: {YearPublished}, Duration: {Duration} minutes");
        }
    }
}
