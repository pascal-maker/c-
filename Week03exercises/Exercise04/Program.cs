
// Maak een lijst aan die alle soorten verzamelobjecten kan bevatten
// Dankzij polymorfisme kan een List<Collectible> zowel Wine, Coin, ComicBooks als PostStamps bevatten
List<Collectible> collectibles = new List<Collectible>();

// Maak ComicBook objecten aan (erven van Collectible)
// Polymorfisme: we kunnen ComicBooks behandelen als Collectible
Collectible comicbook1 = new ComicBooks("amazingspiderman", 2008, 12.50, "Stan-lee");
Collectible comicbook2 = new ComicBooks("antman", 2018, 14.50, "Stan-lee");

// Maak Wine objecten aan (erven van Collectible)
// Wine heeft extra eigenschappen (WineType, AlcoholPercentage, Country) maar is nog steeds een Collectible
Collectible wine1 = new Wine("southafricanwine", 2000, 18.00, Wine.WineType.RED, 2.50, "South Africa");
Collectible wine2 = new Wine("francewine", 2012, 198.00, Wine.WineType.SPARKLING, 4.50, "France");

// Maak PostStamp objecten aan (erven van Collectible)
Collectible PostStamp1 = new PostStamps("bpost", 1990, 17.00, "Garfield");
Collectible PostStamp2 = new PostStamps("postnl", 2000, 18.00, "Tintin");

// Voeg alle verzamelobjecten toe aan de lijst
// Polymorfisme: alle verschillende types kunnen in dezelfde lijst
collectibles.Add(comicbook1);
collectibles.Add(comicbook2);
collectibles.Add(wine1);
collectibles.Add(wine2);
collectibles.Add(PostStamp1);
collectibles.Add(PostStamp2);

// Sorteer de lijst alfabetisch op naam
// Dit werkt omdat Collectible IComparable implementeert (CompareTo methode)
collectibles.Sort();

// Loop door alle verzamelobjecten heen
// Runtime polymorfisme: de juiste ToString() en CollectType worden aangeroepen
foreach (var item in collectibles)
{
    // Toon basisinformatie van het object
    // De juiste ToString() wordt aangeroepen (Wine.ToString(), ComicBooks.ToString(), etc.)
    Console.WriteLine(item.ToString());

    // Toon het type verzamelobject
    // Abstracte property CollectType wordt geïmplementeerd door elke subklasse
    Console.WriteLine("Type: " + item.CollectType);

    // Toon de startprijs voor bieden
    // Virtual methode StartBidPrice kan overschreven worden door subklassen
    Console.WriteLine("Start bid: " + item.StartBidPrice);

    // Voeg een lege regel toe voor leesbaarheid
    Console.WriteLine();
}



