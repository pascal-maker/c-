using library.models;

// Maak boeken aan
Book b1 = new Book(1, "Harry Potter & Goblet of Fire", 2004, "J.K. Rowling");
Book b2 = new Book(2, "Harry Potter & The Secret Chamber", 2008, "J.K. Rowling");

// Maak magazines aan
Magazine m1 = new Magazine(1, "Forbes", 2008, 12);
Magazine m2 = new Magazine(2, "Quote 500", 2023, 12);

// Maak DVD's aan
DVD d1 = new DVD(1, "Cars", 2012, 300);
DVD d2 = new DVD(2, "Mission Impossible", 2018, 400);

// Alle items in één lijst stoppen (van type LibraryItem)
// Dankzij polymorfisme kan een lijst van LibraryItem zowel Book, Magazine als DVD bevatten
List<LibraryItem> librarythings = new List<LibraryItem> { b1, b2, m2, m1, d1, d2 };

// Voor elk item in de lijst → de juiste PrintDetails() methode wordt aangeroepen
// (runtime polymorfisme: welke override hangt af van het werkelijke type)
foreach (var librarything in librarythings)
{
    librarything.PrintDetails();
}
