namespace menu.Models
{
    public class Course
    {
        public int ID {get;set;}

        public string Name{ get;set;}

        public double Price {get;set;}


        public Course(int id,string name,double price)
        {
            ID = id;
            Name = name;
            Price = price;
        }


    }
}