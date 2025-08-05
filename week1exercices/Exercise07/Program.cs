Dictionary<string, int> scores = new Dictionary<string, int> { { "Jan", 3 }, { "Paul", 2 }, { "Jef", 5 }, { "Bram", 0 }, { "Pieter", 4 }, { "Koen", 0 } };
 DisplayGrades(scores);

static void DisplayGrades(Dictionary<string, int> scores)
{ 

    foreach ( var score in scores)
    {

        switch (score.Value)

        {   
             case 0:
                Console.WriteLine($" {score.Key} ->Insufficient");
                break;
            case 1:
                Console.WriteLine($" {score.Key} ->Insufficient");
                break;
            case 2:
                Console.WriteLine($" {score.Key} ->Insufficient");
                break;

            case 3:
                Console.WriteLine($" {score.Key} ->Average");
                break;


            case 4:
                Console.WriteLine($" {score.Key} ->Average");
                break;

            case 5:
                Console.WriteLine($" {score.Key} ->ok");
                break;

            default :
                break;    
   
}
    
    }
    
}


