// Importeer de benodigde namespaces om de modellen, repositories en services te gebruiken
using Swagger.Models;
using Swagger.Repositories;
using Swagger.Service;
using System.Linq;

// Definieer de namespace voor de Swagger applicatie
namespace Swagger
{
    // Definieer de Swagger klasse die het hoofdprogramma bevat
    public class Swagger
    {
        // Definieer het hoofdentry point als een async methode
        public static async Task Main(string[] args)
        {
            // Maak een nieuwe instantie van de TodoArtistApplicationService voor business logic
            var TodoArtistApplicationService = new TodoArtistApplicationService();  // Maak de business logic layer

            // Boolean variabele om de hoofdprogramma loop te controleren
            // Wanneer dit true wordt, stopt het programma
            bool running = true;

            // Hoofdprogramma loop - dit draait tot de gebruiker kiest om te stoppen
            while (running)
            {
                // Wis het console scherm om een schoon menu te tonen
                

                // Toon de hoofdmenu opties
                Console.WriteLine("=== Console Arist System ===");
                Console.WriteLine("1. Get All Artist");
                Console.WriteLine("2. Get All Concerts");
                Console.WriteLine("3. Get artist and their concerts");
                Console.WriteLine("4 Exit");
                Console.Write("\nEnter your choice (1-4): ");

                // Lees de keuze van de gebruiker van de console
                string choice = Console.ReadLine();

                // Switch statement om verschillende menu keuzes af te handelen
                switch (choice)
                {
                    case "1":
                        // Toon een header voor het ophalen van artiesten
                        Console.WriteLine("\nFetching all artists..");
                        // Roep de service aan om alle artiesten asynchroon op te halen
                        var artists = await TodoArtistApplicationService.GetAllArtists();
                        // Loop door elke artiest en toon deze
                        foreach (var artiste in artists)
                            Console.WriteLine(artiste);
                        break;
                    case "2":
                        // Toon een header voor het ophalen van concerten
                        Console.WriteLine("\nFetching all concerts..");
                        // Roep de service aan om alle concerten asynchroon op te halen
                        var concerts = await TodoArtistApplicationService.GetAllConcerts();
                        // Loop door elk concert en toon deze
                        foreach (var concert in concerts)
                            Console.WriteLine(concert);
                        break;
                    case "3":
                        // Vraag de gebruiker om een artiest ID in te voeren
                        Console.Write("Enter artist ID:");
                        var idInput = Console.ReadLine();
                        // Probeer de input als een integer te parsen
                        if (int.TryParse(idInput, out var artistId))
                        {
                            // Haal alle artiesten op en zoek de specifieke artiest op ID
                            var artist = (await TodoArtistApplicationService.GetAllArtists())
                                .FirstOrDefault(a => a.Id == artistId);
                            // Controleer of de artiest gevonden is
                            if (artist == null)
                            {
                                // Toon bericht als artiest niet gevonden is
                                Console.WriteLine("Artist not found");
                                break;
                            }

                            // Lege regel voor spacing

                            // Toon de artiest informatie
                            Console.WriteLine($"\n Artist {artist.Id}|{artist.Name}{artist.Country}- Genre: {artist.Genre}");
                            // Haal concerten op voor deze artiest
                            var artistConcerts = await TodoArtistApplicationService.GetConcertForArtist(artistId);
                            // Controleer of er concerten zijn gevonden
                            if (artistConcerts.Count == 0)
                            {
                                // Toon bericht als er geen concerten zijn
                                Console.WriteLine("No concerts found for this artists");

                            }

                            else
                            {
                                // Loop door elke concert en toon deze
                                foreach (var c in artistConcerts)

                                    Console.WriteLine(c);

                            }

                        }

                        else
                        {
                            // Toon bericht bij ongeldige input
                            Console.WriteLine("Invalid id");
                        }

                            break;
                               case "4":
                                // Zet de running flag op false om het programma te stoppen
                                running = false;
                                Console.WriteLine("Goodbye!");
                                break;

                            default:
                                // Handel ongeldige menu keuzes af
                                Console.WriteLine("Invalid choice. Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        }

                }
            }

        }
    
