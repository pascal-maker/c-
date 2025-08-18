namespace animals.models                 // Namespace waarin de Dog-klasse zich bevindt
{
    // De Dog-klasse erft van de Animal-klasse (Dog is een type Animal)
    public class Dog : Animal
    {
        // Eigenschap (property) voor het ras van de hond
        public string Breed { get; set; }

        // Constructor voor Dog
        // Parameters: name (naam van de hond), age (leeftijd), breed (ras)
        // De constructor roept de base-constructor van Animal aan met name en age
        public Dog(string name, int age, string breed) : base(name, age)
        {
            Breed = breed; // Stel de eigenschap Breed in met de waarde uit de parameter
        }

        // Override van de virtuele methode MakeSound() uit de Animal-klasse
        // Dit zorgt ervoor dat Dog een eigen geluid maakt
        public override void MakeSound()
        {
            Console.WriteLine("Wooof"); // Geluid van de hond
        }
    }
}
