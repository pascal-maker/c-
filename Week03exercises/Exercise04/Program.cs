using System;
using System.Collections.Generic;
namespace Ct.Ai.Models
{
    class Collectibles
    {
        static void Main()
        {
            List<Wine> wines = new List<Wine>
        {
            new Wine("Chateau Margaux",2015,500.00,15.00,"France",WineType.RED),
            new Wine("Chateau Pieter",2018,700.00,45.00,"Spain",WineType.WHITE),
            new Wine("Pinot Rouge",2008,845.00,44.40,"South-Africa",WineType.ROSE),



        };

            List<PostStamp> poststamps = new List<PostStamp>
        {
                new PostStamp("Bpoststamp",2008,12.50,"garfield"),
                new PostStamp("PostNL",2020,14.80,"smurfs"),
                new PostStamp("Bpost",2024,14.99,"tintin"),


        };


            List<ComicBook> comicbooks = new List<ComicBook>
        {
                new ComicBook("spiderman",1990,14.89,"marvel","stanlee"),
                new ComicBook("badman",1949,15.89,"dc","unknown"),
                new ComicBook("antman",2009,15.87,"marvel","stanlee"),



        };

            Console.WriteLine("###Wines###");
            foreach (var wine in wines)
            {
                Console.WriteLine(wine);
                Console.WriteLine($"Start Bid Price: {wine.StartBidPrice}");
                Console.WriteLine($"Collect Type: {wine.CollectType}");
                Console.WriteLine();

            }

            foreach (var poststamp in poststamps)
            {
                Console.WriteLine(poststamp);
                Console.WriteLine($"Start Bid Price: {poststamp.StartBidPrice}");
                Console.WriteLine($"Collect Type: {poststamp.CollectType}");
                Console.WriteLine();

            }

            foreach (var comicbook in comicbooks)
            {
                Console.WriteLine(comicbook);
                Console.WriteLine($"Start Bid Price: {comicbook.StartBidPrice}");
                Console.WriteLine($"Collect Type: {comicbook.CollectType}");
                Console.WriteLine();

            }

            List<Collectible> collectibles = new List<Collectible>();
            collectibles.AddRange(wines);
            collectibles.AddRange(poststamps);
            collectibles.AddRange(comicbooks);

            collectibles.Sort();

            Console.WriteLine("### Sorted collectibles###");
            foreach (var collectible in collectibles)
            {
                Console.WriteLine(collectible);
            }




        
        }
    }
}