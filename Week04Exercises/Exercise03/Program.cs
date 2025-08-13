
using System;
using System.Collections.Generic;

namespace Exercise03.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var beers = new List<Beer>();

            try { beers.Add(new Beer("jupla", "delirium", -1.0m, "yellow")); }
            catch (BeerException ex) { Console.WriteLine($"Invalid beer: {ex.Message}"); }

            try { beers.Add(new Beer("yessbeer", "stella", 8.0m, "blond")); }
            catch (BeerException ex) { Console.WriteLine($"Invalid beer: {ex.Message}"); }

            try { beers.Add(new Beer("Kriek", "stella", -7.0m, "yellow")); }
            catch (BeerException ex) { Console.WriteLine($"Invalid beer: {ex.Message}"); }

            foreach (var beer in beers)
            {
                Console.WriteLine(beer);
                Console.WriteLine();
            }
        }
    }
}
