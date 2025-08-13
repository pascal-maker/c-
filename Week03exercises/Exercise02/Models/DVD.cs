namespace Ct.Ai.Models

{
    public class DVD : LibraryItem
    {
        public int Duration { get; set; }


        public DVD(int id, string title, int yearpublished, int duration) : base(id, title,yearpublished)
        {
            Duration = duration;

        }





         public  override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine ($"Duration: {Duration} minutes");
        }





    }
}   