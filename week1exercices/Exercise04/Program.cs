// We maken een lijst met favoriete kleuren van kinderen
List<string> list_favorite_colors_children = new List<string>() 
{ 
    "green", "yellow", "pink", "blue", "red", 
    "green", "pink", "yellow", "yellow", 
    "black", "pink", "brown" 
};

// We roepen de methode CountColors aan en slaan het resultaat (dictionary) op in een variabele
// "var" betekent dat de compiler zelf het type afleidt → hier wordt dat Dictionary<string,int>
var colorCount = CountColors(list_favorite_colors_children);

// We printen de dictionary netjes uit
PrintColorCount(colorCount);



// ---------------------------
// Methode 1: CountColors
// ---------------------------
static Dictionary<string,int> CountColors(List<string> colors)
// Returntype = Dictionary<string,int>
// Methode = CountColors
// Parameter = List<string> colors (onze kleurenlijst)
{
    // We maken een nieuwe lege dictionary aan
    // Key   = string (de kleur, bv. "green")
    // Value = int (hoe vaak die kleur voorkomt)
    var colorCount = new Dictionary<string,int>();

    // We gaan elke kleur uit de lijst overlopen
    foreach (var color in colors)
    {
        // Als de kleur al in de dictionary bestaat → waarde verhogen met 1
        if (colorCount.ContainsKey(color))
            colorCount[color]++;

        // Als de kleur er nog niet in zit → toevoegen met waarde 1
        else
            colorCount[color] = 1;
    }

    // Uiteindelijk returnen we de dictionary (alle kleuren met hun telling)
    return colorCount;
}



// ---------------------------
// Methode 2: PrintColorCount
// ---------------------------
static void PrintColorCount(Dictionary<string,int> colorCount)
// void → omdat we niets teruggeven, enkel afdrukken
// Parameter = Dictionary<string,int> (de telling van kleuren)
{
    // We lopen elk element (key-value pair) van de dictionary af
    foreach (var entry in colorCount)
    {
        // entry.Key = de kleur
        // entry.Value = het aantal
        Console.WriteLine($"The color {entry.Key} appears {entry.Value} time/times");
    }
}
