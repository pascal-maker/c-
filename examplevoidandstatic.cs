using System;

public class Car
{
    public string Brand { get; set; }
    public string Color { get; set; }
    public int Fuel { get; set; }

    // Instance method → belongs to each object
    public void Drive()
    {
        Console.WriteLine($"{Brand} is driving with {Fuel} liters of fuel!");
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car { Brand = "BMW", Color = "Red", Fuel = 50 };
        Car car2 = new Car { Brand = "Tesla", Color = "Black", Fuel = 80 };

        car1.Drive(); // BMW is driving with 50 liters of fuel!
        car2.Drive(); // Tesla is driving with 80 liters of fuel!
    }
}
