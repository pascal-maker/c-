using System;
Dictionary<string, List<int>> dict_aankopen = new Dictionary<String, List<int>>();
dict_aankopen.Add("jan", new List<int>() { 100, 50, 20 });
dict_aankopen.Add("piet", new List<int>() { 10, 70, 20, 4, 58, 542 });
dict_aankopen.Add("karel", new List<int>() { 9 });
dict_aankopen.Add("sandra", new List<int>() { 45, 45, 10 });
//voorbeeldcode
//we gaan nu de shoppingbaskets gaan bepalen onze functi emet de tresholds

var ClientCount = GetExpensiveShoppingBaskets(dict_aankopen, 200);
//vervolgens printen we de klanten met geld die de treshold 

PrintclientCount(ClientCount);

// een klant is rijk als die meer dan 200 in treshold value efft
//dus als portefeuille >= (treshold = 200)

static List<string> GetExpensiveShoppingBaskets(Dictionary<string,List<int>> dict_aankopen, int treshold)
{
    //lijstmetklantendiegenoeggeldhebben
    var ClientCount = new List<string>();
    //doorloop elke klant

    foreach (var aankoop in dict_aankopen)
    {
        //vooorwaarde klant rijk genoeg

        int klantuitgaven = aankoop.Value.Sum();
        if (klantuitgaven > treshold)
        {
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
// print de klanten uit die ana treshold voldoen
{
    foreach (var entry in ClientCount)
    {
        Console.WriteLine($"The client {entry} exceeds the treshold ");
    }
}

