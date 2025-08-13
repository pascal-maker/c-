// Voorbeelddata: lokaalcode -> capaciteit (aantal plaatsen)
Dictionary<string, int> locations = new Dictionary<string, int>
{
    { "KWE.P.0.002", 200 },
    { "KWE.P.1.103", 20 },
    { "KWE.A.1.103", 60 },
    { "KWE.A.1.104", 30 },
    { "KWE.A.1.302", 64 },
    { "KWE.A.1.301", 64 }
};

// We starten met het bepalen van de coronaproof lokalen voor groepen van 30 studenten
// Let op: de naam 'classroomCount' is eigenlijk misleidend: dit is een lijst met lokaalcodes.
// Beter: 'eligibleClassrooms' of 'coronaClassrooms'.
//bepeaal alijd je varibale
var classroomCount = DetermineCoronaClassrooms(locations, 30);

// Vervolgens printen we de gevonden lokalen
//dan orintfuntie
PrintclassroomCount(classroomCount);

/// <summary>
/// Bepaalt welke lokalen coronaproof zijn op basis van een groepsgrootte.
/// Een lokaal is coronaproof als capaciteit >= (groupSize * 2).
/// </summary>
/// <param name="locations">Dictionary met lokaalcode (string) en capaciteit (int).</param>
/// <param name="groupSize">Grootte van de groep studenten.</param>
/// <returns>Gesorteerde lijst met lokaalcodes die voldoen.</returns>
static List<string> DetermineCoronaClassrooms(Dictionary<string, int> locations, int groupSize)
{
    // Lijst die we zullen vullen met lokaalcodes die groot genoeg zijn
    var classroomCount = new List<string>();

    // Doorloop elk lokaal (Key = code, Value = capaciteit)
    foreach (var location in locations)
    {
        // Voorwaarde: lokaal is groot genoeg als capaciteit minstens 2x de groepsgrootte is de groote van de klas vinden we terug in de value
        if (location.Value >= groupSize * 2)
        {
            // Voeg de lokaalcode toe aan de resultaten we willend eklanamen dus de keu
            classroomCount.Add(location.Key);
        }
        else
        {
            // Indien niet groot genoeg, geven we feedback in de console
            // (opmerking: dit print voor elk te klein lokaal een lijn)
            Console.WriteLine($"Class '{location.Key}' is not big enough");
        }
    }

    // Sorteer alfabetisch op lokaalcode voor consistente output
    classroomCount.Sort();

    // Geef de lijst terug
    return classroomCount;
}

/// <summary>
/// Print alle coronaproof lokalen in de console.
/// </summary>
/// <param name="classroomCount">Lijst met lokaalcodes die voldoen.</param>
static void PrintclassroomCount(List<string> classroomCount)
{
    // Doorloop elke lokaalcode en print een duidelijke boodschap
    foreach (var entry in classroomCount)
    {
        Console.WriteLine($"The class {entry} is corona proof");
    }

    // (optioneel) Je zou hier ook kunnen printen hoeveel er gevonden zijn.
    // Console.WriteLine($"Total corona-proof classrooms: {classroomCount.Count}");
}
