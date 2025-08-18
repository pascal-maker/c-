namespace library.models                 // Namespace waarin de Magazine-klasse zich bevindt
{
    // De Magazine-klasse erft van de LibraryItem-klasse (Magazine is een type LibraryItem)
    public class Magazine : LibraryItem
    {
        // Eigenschap (property) voor het uitgavenummer van het magazine
        public int IssueNumber { get; set; }

        // Constructor voor Magazine
        // Parameters:
        //   id             -> Unieke identificatie van het magazine
        //   title          -> Titel van het magazine
        //   yearpublished  -> Publicatiejaar van het magazine
        //   issuenumber    -> Uitgavenummer van het magazine
        // De constructor roept de base-constructor van LibraryItem aan om ID, Title en YearPublished in te stellen
        public Magazine(int id, string title, int yearpublished, int issuenumber) 
            : base(id, title, yearpublished)
        {
            IssueNumber = issuenumber; // Stel de eigenschap IssueNumber in met de waarde uit de parameter
        }

        // Override van de virtuele methode PrintDetails() uit de LibraryItem-klasse
        // Dit zorgt ervoor dat Magazine zijn eigen details kan printen, inclusief het uitgavenummer
        public override void PrintDetails()
        {
            Console.WriteLine($"ID: {ID} Title: {Title}, Year: {YearPublished}, IssueNumber: {IssueNumber}");
        }
    }
}
