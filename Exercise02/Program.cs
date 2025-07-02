using System;
class Exercise02
{
    static void Main()
    {
        Console.WriteLine("Enter a number for a:");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a number for b:");
        int b = Convert.ToInt32(Console.ReadLine());

        int c = a + b;


       Console.WriteLine($" The sum of {a} and {b} is {c}");
    }
}



