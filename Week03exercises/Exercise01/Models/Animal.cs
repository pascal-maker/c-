namespace animals.models
{
    /// <summary>
    /// Base class (superklasse) Animal.
    /// Andere dieren kunnen hiervan erven (zoals Dog).
    /// </summary>
    public class Animal
    {
        // Eigenschap Name (naam van het dier)
        public string Name { get; set; }

        // Eigenschap Age (leeftijd van het dier)
        public int Age { get; set; }

        // Constructor → elke Animal moet een naam en leeftijd hebben
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        /// Virtuele methode → kan overschreven worden in subklassen (zoals Dog).
        /// Als een subklasse geen eigen override geeft, wordt deze standaard uitgevoerd.
        /// </summary>
        public virtual void MakeSound()
        {
            Console.WriteLine("unknown sound"); // default geluid
        }
    }
}
