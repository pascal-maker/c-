using System;
class Exercise03
{
    static void Main()
    {
        
        Console.WriteLine("Enter a option");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("Sum");
                Console.WriteLine("Enter a number for a:");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a number for b:");
                int b = Convert.ToInt32(Console.ReadLine());

                int c = a + b;


                Console.WriteLine($" The sum of {a} and {b} is {c}");
                break;

            case 2:
                Console.WriteLine("Substraction");
                Console.WriteLine("Enter a number for d:");
                int d = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a number for e:");
                int e = Convert.ToInt32(Console.ReadLine());

                int f = d - e;


                Console.WriteLine($" The substraction of {d} and {e} is {f}");
                break;

            case 3:
                Console.WriteLine("Divide");
                Console.WriteLine("Enter a number for g:");
                int g = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a number for h:");
                int h = Convert.ToInt32(Console.ReadLine());

                int i = g / h;


                Console.WriteLine($" The divide of  {g} and {h} is {i}");
                break;

            case 4:
                Console.WriteLine("Multiply");
                Console.WriteLine("Enter a number for j:");
                int j = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a number for k:");
                int k = Convert.ToInt32(Console.ReadLine());

                int l = j * k;


                Console.WriteLine($" The multiplication of  {j} and {k} is {l}");
                break;    
                
            case 5:
                Console.WriteLine("Exit.");
                break;    
                
                    
                

    


                   
        }
        
    }
}
