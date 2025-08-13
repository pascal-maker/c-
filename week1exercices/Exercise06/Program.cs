Dictionary<string, List<int>> dict_aankopen = new Dictionary<String, List<int>>();
dict_aankopen.Add("jan", new List<int>() { 100, 50, 20 });
dict_aankopen.Add("piet", new List<int>() { 10, 70, 20, 4, 58, 542 });
dict_aankopen.Add("karel", new List<int>() { 9 });
dict_aankopen.Add("sandra", new List<int>() { 45, 45, 10 });


var aankopenCount =  GetExpensiveShoppingBaskets(dict_aankopen, 200);
PrintaankopenCount(aankopenCount);

static List<string> GetExpensiveShoppingBaskets(Dictionary<string, List<int>> dict_aankopen, int treshold)
{ 

    var aankopenCount = new List<string>();
    foreach ( var aankoop in dict_aankopen)
    {
        int totalValue = aankoop.Value.Sum();
        if (totalValue > treshold)
        {
            aankopenCount.Add(aankoop.Key);
        }


    }
    
   return aankopenCount;
}


static void PrintaankopenCount(List<string> aankopenCount)
{
    Console.WriteLine("Customers who shopping exceeds the threshold are:");
    foreach (var aankoop in aankopenCount)
    {
        Console.WriteLine($"{aankoop}");
    }
}
