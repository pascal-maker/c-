using System;
using System.Collections.Generic;
class Exercise04
{
    public static Dictionary<string, int> CountColors(List<string> colors)
    {
        Dictionary<string, int> colorCount = new Dictionary<string, int>();
        foreach (string color in colors)
        {
            if (colorCount.ContainsKey(color))
            {
                colorCount[color]++;
            }
            else
            {
                colorCount[color] = 1;
            }
        }

        return colorCount;

    }

    static void Main(string[] args)

    {
        List<string> favoriteColors = new List<string>()
        {
           "green","yellow","pink","blue","red","green","pink",
           "yellow","yellow","black","pink","brown"
        };

        Dictionary<string, int> result = CountColors(favoriteColors);
        foreach (var entry in result)
        {
            Console.WriteLine($" Color' {entry.Key}' appears {entry.Value} times. ");
        }
    }
}