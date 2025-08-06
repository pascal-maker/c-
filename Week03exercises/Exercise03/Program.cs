using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using Ct.Ai.Models;

namespace Ct.Ai.Models
{
    class Vehicles
    {
        static void Main(string[] args)
        {
            Vehicle boat = new Boat("green", 120, "saltywater");
            boat.DescribeVehicle();


            List<Vehicle> coolvehicles = new List<Vehicle>
            {
                new Car("green",180,4),
                new Boat("pink",120.5,"sweetwater"),
                new Car("Brown",179.5,8)
            };


            foreach (Vehicle coolvehicle in coolvehicles)
            {
                if (coolvehicle is IRefuel Refuel)
                {
                    Console.WriteLine($"{coolvehicle} is refuelable");
                    Refuel.Refuel();
                }

                else
                {
                    Console.WriteLine($"{coolvehicle} is not refuelable ");
                } 
            
            }

            



        }
    }
}