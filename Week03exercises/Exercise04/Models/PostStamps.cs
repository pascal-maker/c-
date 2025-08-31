public class PostStamps : Collectible
{
    public string Image {get;set;}


    public PostStamps(string name,int yearoforigin, double price, string image)
     :base(name,yearoforigin,price)
    {
        Image = image;
    }


    public override string ToString()
    {
        return $"Name: {Name}";
    }


    public override string CollectType
    {
        get {return "post stamps";}
    }
    





}