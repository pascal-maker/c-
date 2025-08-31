namespace library.models
{
    /// <summary>
    /// Subklasse Magazine erft van LibraryItem.
    /// Bevat extra eigenschap: IssueNumber (editienummer).
    /// </summary>
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(int id, string title, int yearpublished, int issuenumber)
            : base(id, title, yearpublished)
        {
            IssueNumber = issuenumber;
        }

        // Override → toont details van een Magazine inclusief uitgavenummer
        public override void PrintDetails()
        {
            Console.WriteLine($"ID: {ID}, Title: {Title}, Year: {YearPublished}, IssueNumber: {IssueNumber}");
        }
    }
}
