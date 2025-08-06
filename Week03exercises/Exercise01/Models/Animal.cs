namespace Ct.Ai.Models

{
    public class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }


        public Animal(string name, int age)
        {
            Name = name;
            Age = age;

        }



        public override string ToString()
        {
            return $" {Age}, {Name}";
        }


        public  virtual string MakeSound()
        {
            return  "Unknown Sound";
        }





    }
}   