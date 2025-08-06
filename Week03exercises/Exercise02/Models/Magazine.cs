namespace Ct.Ai.Models

{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }


        public Magazine(int id, string title, int yearpublished, int issuenumber) : base(id, title,yearpublished)
        {
            IssueNumber = issuenumber;

        }





         public  override void PrintDetails()
        {   
            base.PrintDetails();
            Console.WriteLine ($" {ID}, {Title},{YearPublished}, {IssueNumber}");
        }





    }
}   