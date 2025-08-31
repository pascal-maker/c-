public class ComicBooks : Collectible
{
    public string Author {get;set;}


    public ComicBooks(string name,int yearoforigin, double price, string author)
     :base(name,yearoforigin,price)
    {
        Author = author;
    }


    public override string ToString()
    {
        return $"Name: {Name},Author:{Author}";
    }


    public override string CollectType
    {
        get {return "comic book";}
    }
    





}