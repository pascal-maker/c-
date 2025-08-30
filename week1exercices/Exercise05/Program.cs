// Voorbeelddata: lokaalcode -> capaciteit (aantal plaatsen)
// We maken een dictionary: Key = lokaalcode (string), Value = capaciteit (int)
Dictionary<string, int> locations = new Dictionary<string, int>
{
    { "KWE.P.0.002", 200 },
    { "KWE.P.1.103", 20 },
    { "KWE.A.1.103", 60 },
    { "KWE.A.1.104", 30 },
    { "KWE.A.1.302", 64 },
    { "KWE.A.1.301", 64 }
};
//we stellen de bepaalde capaciteit op
// We bepalen de coronaproof lokalen voor een groep van 30 studenten
// Hier roepen we de methode DetermineCoronaClassrooms aan en geven
// de dictionary + capacity door als parameters
Console.WriteLine("Enter the preferred capacity:");

int capacity = int.Parse(Console.ReadLine());

var coronaproofclassroomCount = DetermineCoronaClassrooms(locations,capacity);
// We printen de gevonden coronaproof lokalen we oakkend e varibale cornaproofclassroomcount om het ons makkelijker te maken dit op te slaan in Princtclasroomcount

PrintclassroomCount(coronaproofclassroomCount);

// ---------------------------
// Methode 1: DetermineCoronaClassrooms
// ---------------------------
/// <summary>
/// Bepaalt welke lokalen coronaproof zijn op basis van een groepsgrootte.
/// Een lokaal is coronaproof als capaciteit >= (groupSize * 2).
/// </summary>

static List<string> DetermineCoronaClassrooms(Dictionary<string,int> locations, int capacity)
{    // We maken een lege lijst waarin we alle geschikte lokaalcodes gaan opslaan

    var classroomCount = new List<string>();


    // Doorloop elk lokaal in de dictionary
    // location.Key   = lokaalcode
    // location.Value = capaciteit

    foreach (var location in locations)
    {          // Voorwaarde: lokaal is coronaproof als capaciteit minstens 2x de groepsgrootte is

        if (location.Value >= capacity *2)
        {             // Als de capaciteit groot genoeg is → voeg de lokaalcode toe aan de lijst

            classroomCount.Add(location.Key);
        }

        else
        {     // Anders printen we een boodschap dat dit lokaal niet groot genoeg is
            Console.WriteLine($" Class '{location.Key}' is not big enough");
        }


    }

        // We sorteren de lijst alfabetisch op lokaalcode voor overzicht


    classroomCount.Sort();
       // We geven de lijst terug naar de aanroeper

    return classroomCount;
}

// ---------------------------
// Methode 2: PrintclassroomCount
// ---------------------------
/// <summary>
/// Print alle coronaproof lokalen in de console.
/// </summary>

static void PrintclassroomCount(List<string> classroomCount)
{  
        // Doorloop elke lokaalcode in de lijst en print een duidelijke boodschap

    foreach ( var entry in classroomCount)
    {
        Console.WriteLine($" The class {entry} is coronaproof");
    }
}

