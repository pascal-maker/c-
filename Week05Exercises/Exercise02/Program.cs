using System;                         // Nodig voor Console.WriteLine, enz.
using System.Threading.Tasks;         // Nodig voor Task<> en async/await
using Ct.Ai.Models;                   // Toegang tot Artist en Comment klassen
using Ct.Ai.Service;           
using System.Linq;

namespace Ct.Ai
{
   public  class Artists
    {
        public static async Task Main(string[] args)

        {
            var todoArtistService = new TodoArtistApplicationService();


            //Creates a repository object that handles data storage/retrieval for smartphones (e.g., reading/writing from CSV).


//Creates a service layer that uses the repository (repo) to perform higher-level operations like adding, searching, etc.

//This helps keep business logic separate from raw data access.

            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Get all artists");
                Console.WriteLine("2. Get all concerts ");
                Console.WriteLine("3. get artist and their concerts");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // -------------------- ALLE artists OPHALEN --------------------
                         Console.WriteLine("\nFetching all artists..");
                         var artists = await todoArtistService.GetArtists();
                         foreach (var artist in artists)
                             Console.WriteLine(artist);
                        break;

                    case "2":
                        Console.WriteLine("\nFetching all concerts..");
                        var concerts = await todoArtistService.GetConcerts();
                        foreach (var concert in concerts)
                            Console.WriteLine(concert);
                        break;

                    case "3":
                        Console.Write("Enter artist id: ");
                        var idInput = Console.ReadLine();
                        if (int.TryParse(idInput, out var artistId))
                        {
                            // print the artist first
                            var artist = (await todoArtistService.GetArtists())
                                         .FirstOrDefault(a => a.Id == artistId);
                            if (artist == null)
                            {
                                Console.WriteLine("Artist not found.");
                                break;
                            }

                            Console.WriteLine($"\nArtist {artist.Id} | {artist.Name} ({artist.Country}) - Genre: {artist.Genre}");

                            Console.WriteLine($"Fetching concerts for artist {artistId}..");
                            var artistConcerts = await todoArtistService.GetConcertForArtist(artistId);
                            if (artistConcerts.Count == 0)
                            {
                                Console.WriteLine("No concerts found for this artist.");
                            }
                            else
                            {
                                foreach (var c in artistConcerts)
                                    Console.WriteLine(c);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid id.");
                        }
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Bye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try 1-4.");
                        break;
                }
            }
        }
    }
}