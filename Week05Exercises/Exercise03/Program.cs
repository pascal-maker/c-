using System;
using System.Linq;
using System.Collections.Generic;
//creating a list

class Queries
{
    public static void Main()
    {      //exercise1
        {
            List<int> numbers = new List<int>() { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };

            numbers.Sort();
            Console.WriteLine(string.Join(",", numbers));
        }



        //exercise2&3
        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            foreach (var result in values)
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine(result + "Is Even value");
                }

                else
                {
                    Console.WriteLine(result + "Is odd  value");

                }
            }
        }
        //exercise4
        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            foreach (var result in values)
            {
                if (result % 3 == 0)
                {
                    Console.WriteLine(result + "Is Even value");
                }

                else
                {
                    Console.WriteLine("Nope i dont want them");

                }
            }
        }


        //exercise5
        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            foreach (var result in values)
            {
                if (result % 3 == 0 && result % 5 == 0)
                {
                    Console.WriteLine(result + " is  divisble by 3 and 5");
                }


                else
                {
                    Console.WriteLine("its not divisle by 3 and 5");
                }
            }
        }

        //exercise6

        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            foreach (var result in values)
            {
                if (result < 30)
                {
                    Console.WriteLine(result + " smaller than 30");
                }


                else
                {
                    Console.WriteLine("nope is not smaller than 30");
                }
            }
        }

        //exercise7

        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            foreach (var result in values)
            {
                if (result < 30 && result > 20)
                {
                    Console.WriteLine(result + " smaller than 30 and bigger than 20");
                }


                else
                {
                    Console.WriteLine("nope is not smaller than 30 and bigger than 20.");
                }
            }
        }


        //exercise8

        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            int sum = values.Where(v => v > 20 && v < 30).Sum();

            Console.WriteLine($"Sum of numbers between 20 and 30 (exclusive) = {sum}");







        }


        //exercise9


        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            double average = values
            .Where(v => v > 20 && v < 30)
            .Average();
            Console.WriteLine($" Average of numbers between 20 and 30 (exclusive) = {average}");





        }


        //exercise10


        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            int max = values
            .Where(v => v > 20 && v < 30)
            .Max();
            Console.WriteLine($" the Max of all numbers smaller than 30 and bigger than 20 = {max}");





        }


        //exercise11


        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            int min = values
            .Where(v => v > 20 && v < 30)
            .Min();
            Console.WriteLine($" the Min of all numbers smaller than 30 and bigger than 20 = {min}");





        }


        //exercise12


        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            int first = values.First(v => v > 20);
            Console.WriteLine($" the first numbber bigger than 20 {first}");





        }


        //Exercise13


        {
            int[] values = { 74, 9, 56, 88, 63, 47, 35, 96, 18, 71, 3, 54, 25, 41, 99, 14, 66, 82, 7, 50, 28, 92, 64, 1, 76, 39, 48, 81, 16, 59, 5, 31, 84, 19, 12, 60, 43, 97, 8, 27, 53, 65, 10, 4, 85, 22, 94, 46, 11, 40 };
            foreach (var result in values)
            {
                int increase = result + 1;

                Console.WriteLine($" Each number with +1: {increase}");
            }
        }


        
        



        


        
        



    }

}
