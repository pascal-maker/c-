List<string> list_favorite_colors_children = new List<string>() 
{ "green", "yellow", "pink", "blue", "red", "green", "pink", "yellow", "yellow", "black", "pink", "brown" };
//call the countColors function and store the result in a dictonary
var colorCount = CountColors(list_favorite_colors_children);
// print the results
PrintColorCounts(colorCount);

//function to count occurences of each color

static Dictionary<string,int> CountColors(List<string>colors)
{
    var colorCount = new Dictionary<string, int>();
    foreach (var color in colors)
    {
        if (colorCount.ContainsKey(color))
            colorCount[color]++;
        else
            colorCount[color] = 1;

    }
    return colorCount;
}
//function to print the color counts
static void PrintColorCounts(Dictionary<string,int> colorCount)
{
    foreach (var entry in colorCount)
    {
        Console.WriteLine($" The Color {entry.Key} appears {entry.Value} time{(entry.Value > 1 ? "s" : "")}");
    }
}