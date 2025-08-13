using Ct.Ai.Models;
using Ct.Ai.Repositories;
using Ct.Ai.Services;

class Movies
{
    static void Main()
    {
        var repo = new MediaRepository();
        var service = new MediaService(repo);

        var m1 = MediaFactory.Create("movie");
        var s1 = MediaFactory.Create("series");
        var p1 = MediaFactory.Create("podcast");

        var m2 = new Movie("Dune", 155, "sci-fi", "Dennis Villeneuve");


        service.Add(m1);
        service.Add(s1);
        service.Add(p1);
        service.Add(m2);


        Console.WriteLine("== All media ==");
        service.GetAll().ForEach(Console.WriteLine);

        Console.WriteLine("\n== Fetch By title==");
        var found = service.GetByTitle("Dune");
        Console.WriteLine(found is null ? "Not found" : found.ToString());

        Console.WriteLine("\n==Consume One");
        found.Consume();


    }
}