//eerst ga je while loop gebruiken
while(true)
{
    Console.WriteLine("Choose an option");
    //Console.Writeline  om te schrijven naar
    Console.WriteLine("1.Sum:");
    Console.WriteLine("2. Substract:");
    Console.WriteLine("3.Mutiply:");
    Console.WriteLine("4.Divide");
    Console.WriteLine("5.Exit");

    string option = Console.ReadLine();
    //we gebruiken console readline om te lezen wat we geschreven hhebben en slaan dit op in een string
    ProcessMenu(option);
    // we slaan dit onze strinfg als paramter op in onze method process
}   

void ProcessMenu(string option)
//void omdat we niks retourneren maar gewoon uitvoeren en we voeren onze strings uit {} opendoen
{
    if (option =="5")
       Environment.Exit(0);
       //alsoptie 5 is dan doen we environment exit(o) we gaan 

    Console.WriteLine("Value A:");
    //we beginnen met console writeline voor a de waarde voor a schrijven
    int a = int.Parse(Console.ReadLine()) ;
    //we slaan die dan opn int a = i die moet hem eerstgaan int parsen console readline doen
    Console.WriteLine("Value B:");
    int b = int.Parse(Console.ReadLine());
    //idem dito voor b

    switch (option)
    //wedoen dan switch menu
    {
         case"1":
         Console.WriteLine($" The sum is {a + b}");
         // we doen als je optie 1 kiest de som is +b
         break;
         //we sluiten af met break statement anders gaat  het  niet lukken en blifjt die loopen

        case "2":
        Console.WriteLine($"The substraction  is {a-b}");
        break;

        case "3": 
          Console.WriteLine($" The multiplication is {a*b}");
        break;

        case "4":
          if ( b!= 0)
          //hier een specale als b nul want je kan hierdoor niet gaan delen
          Console.WriteLine($" The division is {a/b} ");
          
           else  
          Console.WriteLine("Error cannot divide by zero!");

          break;

        default:
          Console.WriteLine("Invalid option,please try again!");
          break;
          //onze default option als dat is invalid option please try again als je een verkeerd nummer zou intikken






    }

    






}

