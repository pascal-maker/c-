using System;
using System.Linq;
using System.Collections.Generic;
//creating a list

class Maths
{
    public static void Main()
    {      //exercise1
        {
            List<int> numbers = new List<int>() { 75, 11, 54, 48, 63, 47, 35 };
            List<int> numbersa = new List<int>() { 74, 9, 56, 88, 64, 46, 11 };

            numbers.AddRange(numbersa);

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey();
        }



        
        



    }

}
