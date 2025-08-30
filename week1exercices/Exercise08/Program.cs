using System;

class Program
{
    static void Main(string[] args)
    {
        // Vraag de naam van de gebruiker
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        // Maak een Random-object om een willekeurig getal te genereren
        Random random = new Random();

        // random.Next(1, 101) genereert een getal tussen 1 en 100 (101 is exclusief!)
        int returnValue = random.Next(1, 101);

        // Variabelen voor het gokgetal en het aantal pogingen
        int guess = 0;
        int attempts = 0;

        // Intro-bericht
        Console.WriteLine($"Hello {name}, I am thinking of a number between 1 and 100. Can you guess what it is?");

        // While-loop loopt door zolang de gok niet gelijk is aan het juiste getal
        while (guess != returnValue)
        {
            // Vraag de gebruiker om een gok in te geven
            Console.Write("Enter your guess: ");
            guess = Convert.ToInt32(Console.ReadLine());

            // Tel het aantal pogingen op
            attempts++;

            // Als de gok te laag is
            if (guess < returnValue)
            {
                Console.WriteLine("Too low, try again.");
            }
            // Als de gok te hoog is
            else if (guess > returnValue)
            {
                Console.WriteLine("Too high, try again.");
            }
            // Als de gok juist is
            else
            {
                Console.WriteLine($" Congratulations {name}! Well done! The answer was {returnValue}.");
                Console.WriteLine($"You guessed it in {attempts} attempts.");
            }
        }
    }
}
