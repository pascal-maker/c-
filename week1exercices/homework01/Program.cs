Console.WriteLine("Enter the price of the construction land:");
int construction_land = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the price of the building:");
int building = int.Parse(Console.ReadLine());

double total_cost = (building + construction_land) * 1.21;

Console.WriteLine($"The total cost of the project is: {total_cost}  euro");
