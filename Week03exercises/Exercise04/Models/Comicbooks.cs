// Klasse die een stripboek (comic book) voorstelt
// Erft van de abstracte klasse Collectible
public class Comicbooks : Collectible
{
    // Eigenschap voor de auteur van het stripboek
    public string Author { get; set; }

    // Constructor voor Comicbooks
    // Neemt naam, jaar van oorsprong, prijs en auteur aan
    // Roept de base-constructor van Collectible aan voor naam, jaar en prijs
    public Comicbooks(string name, int yearoforigin, double price, string author) 
        : base(name, yearoforigin, price)
    {
        Author = author; // Stel de auteur in
    }

    // Overschrijving van de ToString()-methode
    // Geeft een tekstuele representatie terug met naam en auteur
    public override string ToString()
    {
        return $" Name : {Name} Author:{Author}";
    }

    // Implementatie van de abstracte CollectType-eigenschap
    // Geeft altijd de string "comic book" terug
    public override string CollectType => "comic book";
}
