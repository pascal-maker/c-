using System;
class Program
{

   static void Main(string[] args)
   {

    Console.Write("Enter your name :");
    string name = Console.ReadLine();

    Random random = new Random();
    int returnValue = random.Next(1, 101);
    int Guess = 0;
    int Attempts = 0;
    Console.WriteLine(" Hello  i am thinking of a number between 1-100. Can you guess what it is?");
    while (Guess != returnValue)
    {

        Console.Write("Enter your guess:");
        Guess = Convert.ToInt32(Console.ReadLine());
        Attempts++;
        if (Guess < returnValue)
            Console.WriteLine(" Too low try again ");


        else if (Guess > returnValue)
            Console.WriteLine(" to high try again ");



        else
            Console.WriteLine($" Congratulations  {name} Well Done ! The answer was {returnValue} in Attempts {Attempts}");


        }
 
   }
   

}

