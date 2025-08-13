using System;
using System.Collections.Generic;
using System.Linq;
using Exercise05.Models;

namespace Exercise05.Models
{
    class Program
    {
        static void Main()
        {
            List<IVehicle> vehicles = new List<IVehicle>()
            {
                 new Caddy(),new Motorcycle(),new Truck(), new Truck()
            };

            var caddies = vehicles.OfType<Caddy>().ToList();

            //display results

            Console.WriteLine($"Found {caddies.Count} caddies:");
            foreach (var caddy in caddies)
            {
                caddy.Drive();
            }
        }


        //get a the caddies from the list using LINQ
    }
}