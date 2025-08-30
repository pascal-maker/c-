// We maken een dictionary met scores: Key = naam student, Value = score (0–5)
Dictionary<string, int> scores = new Dictionary<string, int> 
{ 
    { "Jan", 3 }, 
    { "Paul", 2 }, 
    { "Jef", 5 }, 
    { "Bram", 0 }, 
    { "Pieter", 4 }, 
    { "Koen", 0 } 
};

// We roepen de methode DisplayGrades aan en geven de dictionary 'scores' mee
DisplayGrades(scores);



// ---------------------------
// Methode: DisplayGrades
// ---------------------------
static void DisplayGrades(Dictionary<string,int> scores)
// static → omdat we de methode rechtstreeks willen oproepen
// Returntype = void → we geven niets terug, enkel printen
// Parameter = Dictionary<string,int> (naam + score)
{
    // Doorloop elke entry (student + score) in de dictionary
    foreach (var score in scores)
    {
        // We gebruiken de score.Value (het cijfer) in een switch
        // score.Key = naam van de student
        // score.Value = cijfer (0–5)
        switch (score.Value)
        {
            case 0:
                Console.WriteLine($"{score.Key} -> Insufficient"); // 0 punten
                break;

            case 1:
                Console.WriteLine($"{score.Key} -> Insufficient"); // 1 punt
                break;

            case 2:
                Console.WriteLine($"{score.Key} -> Weak"); // 2 punten
                break;

            case 3:
                Console.WriteLine($"{score.Key} -> Average"); // 3 punten
                break;

            case 4:
                Console.WriteLine($"{score.Key} -> Average"); // 4 punten
                break;

            case 5:
                Console.WriteLine($"{score.Key} -> Ok"); // 5 punten
                break;

            default:
                // Dit vangt waarden buiten 0–5 op (bv. 6 of -1)
                Console.WriteLine("Exit");
                break;
        }
    }
}
