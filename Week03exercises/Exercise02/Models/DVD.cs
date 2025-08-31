namespace library.models
{
    /// <summary>
    /// Subklasse DVD erft van LibraryItem.
    /// Bevat extra eigenschap: Duration (in minuten/seconden).
    /// </summary>
    public class DVD : LibraryItem
    {
        public int Duration { get; set; }

        public DVD(int id, string title, int yearpublished, int duration)
            : base(id, title, yearpublished)
        {
            Duration = duration;
        }

        // Override → toont details van een DVD inclusief speelduur
        public override void PrintDetails()
        {
            Console.WriteLine($"ID: {ID}, Title: {Title}, Year: {YearPublished}, Duration: {Duration} min");
        }
    }
}
