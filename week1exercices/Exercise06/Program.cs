using System;
Dictionary<string, List<int>> dict_aankopen = new Dictionary<String, List<int>>();
dict_aankopen.Add("jan", new List<int>() { 100, 50, 20 });
dict_aankopen.Add("piet", new List<int>() { 10, 70, 20, 4, 58, 542 });
dict_aankopen.Add("karel", new List<int>() { 9 });
dict_aankopen.Add("sandra", new List<int>() { 45, 45, 10 });
//voorbeeldcode
//we gaan nu de shoppingbaskets gaan bepalen onze functie  met welke teshold dan ooko
//we gaan ervoorzorgen dat je zelf ene treshold kunt oopstellen
Console.WriteLine("Enter a treshold:");
int treshold = int.Parse(Console.ReadLine());
var ClientCount = GetExpensiveShoppingBaskets(dict_aankopen, treshold);
//vervolgens printen we de klanten met geld die de treshold behalen

PrintclientCount(ClientCount);

// een klant is rijk als die meer dan  de treshold value heeft
//dus als portefeuille >= treshold)

//we willen een lijst retourneren  dus return type  static List<string> met method die we aanroepen  GetExpensiveShoppingBaskets met als parameters(Dictionary<string,List<int>> dict_aankopen, int treshold)

static List<string> GetExpensiveShoppingBaskets(Dictionary<string,List<int>> dict_aankopen, int treshold)
{
    //lijstmetklantendiegenoeggeldhebben dus we mamen een var ClientCOunt aan diegelijk is aan  new list string
    var ClientCount = new List<string>();
    //doorloop elke klant

    foreach (var aankoop in dict_aankopen)
    {
        //vooorwaarde klant rijk genoeg

        // we maken een int met de naam klantuitgaven aan die gelijk is ana de aankoop is een dictionary de we pakend e value de key is naam de som ervan is veel gemakkelijker

        int klantuitgaven = aankoop.Value.Sum();
        if (klantuitgaven > treshold)
        {  //voegen we toe aan onze list
            ClientCount.Add(aankoop.Key);
        }
        else
        {
            Console.WriteLine($"  Klant bereikt de treshold niet");
        }
    }
    ClientCount.Sort();
    //klanten mooi terugggeven
    return ClientCount;
    //en retourneren
}

static void PrintclientCount(List<string> ClientCount)
// print de klanten uit die aan de  treshold voldoen
{  //een normale forwach dus voor elke klant
    foreach (var entry in ClientCount)
    {
        Console.WriteLine($"The client {entry} exceeds the treshold ");
    }
}

