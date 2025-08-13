using System;
using System.Linq;
using System.Collections.Generic;
//creating a list

class InterSect
{
    public static void Main()
    {      //exercise1
        {
            List<int> listA = new List<int> { 1, 2, 3, 4, 5 };
            List<int> listB = new List<int> { 4, 5, 6, 7, 8 };

            IEnumerable<int> both = listA.Intersect(listB);


            foreach (int id in both)
            {
                Console.WriteLine(id);
            }

           
        }



        
        



    }

}
