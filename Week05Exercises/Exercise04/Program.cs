using System;
using System.Linq;
using System.Collections.Generic;
//creating a list

class Countries
{
    public static void Main()
    {      //exercise1
        {
            List<string> Countries = new List<string>() { "London", "Paris", "Milan", "New York", "Los Angeles" };
            foreach (var country in Countries)
            {
                if (country.Contains('L'))
                {
                    Console.WriteLine($"This  City {country} starts with a L ");
                }
            }



        }



        //exercise2
        {
            List<string> Cities = new List<string>() { "London", "Paris", "Milan", "New York", "Los Angeles" };
            foreach (var city in Cities)
            {
                if (city.StartsWith('L') && city.EndsWith('n'))
                {
                    Console.WriteLine($"This  City {city} starts with a L and ends with a n ");
                }
            }



        }


        //exercise3


         {
            List<string> Cities = new List<string>() { "London", "Paris", "Milan", "New York", "Los Angeles" };
            foreach (var city in Cities)
            {
                if (city.Length == 6)
                {
                    Console.WriteLine($"This  City {city} has extactly 6 characters.");
                }
            }



        }
        

        
        





        

    }

}
