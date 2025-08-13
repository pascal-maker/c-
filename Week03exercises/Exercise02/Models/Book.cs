namespace Ct.Ai.Models

{
    public class Book : LibraryItem
    {
        public string Author { get; set; }


        public Book(int id, string title, int yearpublished, string author) : base(id, title,yearpublished)
        {
            Author = author;

        }





        public  override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine ($" Author: {Author}");
        }





    }
}   