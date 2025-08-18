Console.WriteLine("Welcome user to our shopping sytem");
Console.WriteLine("Enter the amount of trousers bought:");
int trousers = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the amount of vests bought:");
int vests = int.Parse(Console.ReadLine());


Console.WriteLine("Enter the amount of tshirts bought:");
int tshirts = int.Parse(Console.ReadLine());

double total_cost = (trousers * 70.5) + (vests * 100.3) + (tshirts * 20.89);

Console.WriteLine($" The total cost of the project is: {total_cost:F2} euro");

