namespace animals.models
{
    /// <summary>
    /// Dog is een subklasse (derived class) van Animal.
    /// Ze erft alle eigenschappen (Name, Age) en methodes (MakeSound) van Animal.
    /// </summary>
    public class Dog : Animal
    {
        // Extra eigenschap specifiek voor honden
        public string Breed { get; set; }

        // Constructor van Dog:
        // - We voegen zelf "breed" toe
        // - We roepen de constructor van Animal aan via base(name, age)
        public Dog(string name, int age, string breed) : base(name, age)
        {
            Breed = breed;
        }

        /// <summary>
        /// Override van de virtuele methode uit Animal.
        /// Elke hond zegt "Wooof" i.p.v. "unknown sound".
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine("Wooof");
        }
    }
}
