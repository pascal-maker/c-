using library.models;  
// Zorgt ervoor dat we de klassen uit de namespace "library.models" kunnen gebruiken,
// zoals Book, Magazine, DVD en LibraryItem

// Maak een Book-object met:
// ID = 1, Titel = "harrypottergobletoffire", Jaar = 2004, Auteur = "j.k.rowling"
Book b1 = new Book(1, "harrypottergobletoffire", 2004, "j.k.rowling");

// Maak een Magazine-object met:
// ID = 1, Titel = "forbes", Jaar = 2024, Uitgavenummer = 12
Magazine m1 = new Magazine(1, "forbes", 2024, 12);

// Maak een DVD-object met:
// ID = 1, Titel = "pornhub", Jaar = 2023, Duur = 2035 minuten (voorbeeldwaarde)
DVD d1 = new DVD(1, "pornhub", 2023, 2035);

// Maak een lijst van LibraryItem-objecten
// We gebruiken de basisklasse LibraryItem zodat de lijst
// objecten kan bevatten van elk type dat van LibraryItem erft (Book, Magazine, DVD)
List<LibraryItem> librarythings = new List<LibraryItem> { b1, m1, d1 };

// Loop door elk item in de lijst en roep de PrintDetails()-methode aan
// Dankzij polymorfisme zal voor elk object de juiste override van PrintDetails()
// worden uitgevoerd, afhankelijk van het werkelijke type (Book, Magazine of DVD)
foreach (var libraryitem in librarythings)
{
    libraryitem.PrintDetails(); // Print de details van het huidige item
}
