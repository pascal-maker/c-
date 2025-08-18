List<string> list_favorite_colors_children = new List<string>() { "green", "yellow", "pink", "blue", "red", "green", "pink", "yellow", "yellow", "black", "pink", "brown" };
//we starten met onze list
var colorCount = CountColors(list_favorite_colors_children);
//we maken de varibale var colountcount aan is gelijk aan CountCOlors(list_favoirte_childeren) Countcolors is hier een methode naam
PrintColorCounts(colorCount);
//printfunvtie met als parameter colorCount

static Dictionary<string,int> CountColors(List<string> colors)
//we maken een dictionary aan genaamnd COCuntcolor die besatat uit nse ist<string> colors
{
    var colorCount = new Dictionary<string, int>();
    //onze variabele colorCOunt wordt dan een nieuw dicrinary<string,int>
    // dan doen we voor elke kleur in de lisjt kleur van count colors 
    foreach (var color in colors)
    {
        if (colorCount.ContainsKey(color))
            colorCount[color]++;
        else
            colorCount[color] = 1;

    }
    return colorCount;
    // onze variablele colorcunt is ene dtiicnary geworden dus die kan de jeu oprvagen in onze forloop genamad kleur al die er is dan dan tellen wecolorOCunr[color op anders wordt eht 1]

}

static void PrintColorCounts(Dictionary<string,int> colorCount)
// methode printcoloruntcouns aaanrpen die betatauti dciinary<string,int colorOCunt
{
    foreach (var entry in colorCount)
    //foreach aaanropen in colorcount 
    {
        Console.WriteLine($"The color {entry.Key} appears {entry.Value} time{(entry.Value > 1 ? "s" : "")}");
        // printen key verschijtn zoveel keer mer waarden als entry.value>1 dn een dan krijgt time er een s bij of miet
    }
}