using Microsoft.EntityFrameworkCore;
using Exercise03.Data;
using Exercise03.Models;


var options = new DbContextOptionsBuilder<AppDbContext>()
.UseMySQL("server=localhost;database=Ex03;user=root;password=9370")
.Options;

using var db = new AppDbContext(options);

if (!db.Foods.Any())
{
    db.Foods.AddRange(
        new Food { Name = "tomato soup", Description = "Classic Soup", Price = 5.50m, Category = Category.Vegetarian },
        new Food { Name = "burger", Description = "Classic burger", Price = 8.60m, Category = Category.Meat },
        new Food { Name = "Choclate cake", Description = "Classic choco mouse", Price = 8.60m, Category = Category.Dessert }



    );

    db.SaveChanges();

    Console.WriteLine("Seeded foods");


}

Console.WriteLine("foods");
foreach (var f in db.Foods.AsNoTracking().OrderBy(f => f.Id))
{
    Console.WriteLine($"{f.Id}:  {f.Name} {f.Category} €{f.Price:F2} ");

}

