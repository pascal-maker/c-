namespace menu.Models
{
    public class Course
    {
        public int  ID { get; set; }

        public string Name { get; set; }

        public int  Price  { get; set; }




        public Course(int id, string name , int price)
        {
            ID = id;
            Name = name;
            Price = price;
        }


   
    }

}