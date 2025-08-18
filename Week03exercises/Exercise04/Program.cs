// Maak een lege lijst om alle verzamelobjecten (Collectible) in op te slaan
List<Collectible> collectibles = new List<Collectible>();

// Maak 2 Comicbook-objecten en sla ze op als Collectible
Collectible comicbook1 = new Comicbooks("amazingspiderman", 2008, 12.50, "Stan-lee");
Collectible comicbook2 = new Comicbooks("antman", 1990, 14.00, "Stan-lee");

// Maak 2 Wine-objecten en sla ze op als Collectible
Collectible wine1 = new Wine("southafricawine", 2000, 18.00, Wine.WineType.RED, 2.50, "SA");
Collectible wine2 = new Wine("argentianwinen", 1990, 120.00, Wine.WineType.SPARKLING, 22.00, "Argentine");

// Maak 2 PostStamp-objecten en sla ze op als Collectible
Collectible poststamp1 = new PostStamps("bpost", 1990, 17.00, "Garfield");
Collectible poststamp2 = new PostStamps("bpost", 1800, 28.00, "Tintin");

// Voeg alle collecties toe aan 1 lijst
collectibles.Add(comicbook1);
collectibles.Add(comicbook2);
collectibles.Add(wine1);
collectibles.Add(wine2);
collectibles.Add(poststamp1);
collectibles.Add(poststamp2);

// Sorteer de lijst op naam
// Dit werkt omdat de Collectible-klasse IComparable implementeert
collectibles.Sort();

// Doorloop de lijst en toon alle gegevens
foreach (var item in collectibles)
{
    // ToString geeft de beschrijving van het object (afhankelijk van de override in de subklasse)
    Console.WriteLine(item.ToString());

    // Toon het type verzamelobject (bijv. "comic book", "wine", "post stamps")
    Console.WriteLine("Type: " + item.CollectType);

    // Toon de startprijs voor bieden (80% van de originele prijs)
    Console.WriteLine("Start bid: " + item.StartBidPrice);

    // Voeg een scheidingslijn toe voor de leesbaarheid
    Console.WriteLine("----------------------------");
}
