using smartphones.models;
using smartphones.repositories;
using smartphones.Services;

// ========================================
// HOOFDPROGRAMMA - SMARTPHONE MANAGEMENT SYSTEM
// ========================================
// Dit programma demonstreert:
// - Repository Pattern (data toegang)
// - Service Layer Pattern (business logic)
// - Dependency Injection (losse koppeling)
// - Console applicatie met menu systeem

// Maak een repository aan die toegang heeft tot de data (CSV/DB/enz.)
// Repository Pattern: verantwoordelijk voor data opslag en ophalen
var smartPhoneRepository = new SmartPhoneRepository();

// Maak de service laag aan die de logica bevat, en koppel deze aan de repository
// Service Layer: bevat business rules en gebruikt repository voor data toegang
// Dependency Injection: service krijgt repository als parameter
var smartPhoneService = new SmartPhoneService(smartPhoneRepository);

// Flag om het programma te kunnen stoppen
// Wordt true wanneer gebruiker kiest om te stoppen
bool exit = false;

// Eindeloze loop voor het menu, stopt pas wanneer exit = true wordt
// Dit is een typische console applicatie pattern
while(!exit)
{
    // Scherm leegmaken voor betere gebruikerservaring
    // Zorgt ervoor dat het menu altijd bovenaan staat
    Console.Clear();

    // Menu opties - gebruikersinterface
    // Toont alle beschikbare functionaliteiten
    Console.WriteLine("=======Smartphone management system");
    Console.WriteLine("1.View All Smartphones");      // Toon alle smartphones
    Console.WriteLine("2.Add New Smartphone");        // Voeg nieuwe toe
    Console.WriteLine("3.Search By Brand");           // Zoek op merk
    Console.WriteLine("4.Search By Type");            // Zoek op type
    Console.WriteLine("5.Get Smartphone by ID");      // Zoek op ID
    Console.WriteLine("6.Exit");                      // Stop programma
    Console.Write("\nEnter your choice (1-6):");

    // Lees keuze van de gebruiker
    // Console.ReadLine() wacht op Enter toets
    string choice = Console.ReadLine();

    // Switch om de keuze uit te voeren
    // Elke case roept een andere methode aan
    switch (choice)
    {
        case "1":
            GetSmartPhones(smartPhoneService);        // Toon alle smartphones
            break;
        case "2":
            AddSmartPhone(smartPhoneService);         // Voeg nieuwe toe
            break;
        case "3":
            GetSmartPhoneByBrand(smartPhoneService);  // Zoek op merk
            break;
        case "4":
            GetSmartPhoneByType(smartPhoneService);   // Zoek op type
            break;  
        case "5":
            GetSmartPhoneById(smartPhoneService);     // Zoek op ID
            break;
        case "6":
            exit = true;                              // Stop programma
            Console.WriteLine("Goodbye");
            break;
        default:
            // Ongeldige keuze - toon foutmelding
            Console.WriteLine("Invalid choice. Press Enter to continue..");
            Console.ReadLine();                        // Wacht op Enter
            break;
    }
}

// ========================================
// STATIC METHODEN - FUNCTIONALITEITEN
// ========================================
// Deze methoden bevatten de specifieke functionaliteiten
// Ze krijgen de service als parameter (dependency injection)

// ---------------------------
// Methode 1: Toon alle smartphones
// ---------------------------
// Doel: Toont alle smartphones in het systeem
// Gebruikt: Service layer om data op te halen
static void GetSmartPhones(SmartPhoneService smartPhoneService)
{
    // Scherm leegmaken en titel tonen
    Console.Clear();
    Console.WriteLine("=== All Smartphones ===\n");

    // Haal lijst van smartphones op via service
    // Service layer zorgt voor business logic en data toegang
    var smartphones = smartPhoneService.GetSmartPhones();

    // Controleer of er smartphones zijn gevonden
    if(smartphones.Count == 0)
    {
        Console.WriteLine("No smartphones found.");
    }
    else
    {
        // Print elk smartphone object
        // foreach loop door alle smartphones
        foreach (var smartphone in smartphones)
        {
            Console.WriteLine(smartphone);  // ToString() wordt automatisch aangeroepen
        }
    }

    // Toon totaal aantal en wacht op Enter
    Console.WriteLine($"\nTotal smartphones: {smartphones.Count}");
    Console.WriteLine("\nPress Enter to continue..");
    Console.ReadLine();  // Wacht op Enter
}

// ---------------------------
// Methode 2: Nieuwe smartphone toevoegen
// ---------------------------
// Doel: Voegt een nieuwe smartphone toe aan het systeem
// Bevat: Input validatie en error handling
static void AddSmartPhone(SmartPhoneService smartPhoneService)
{
    // Scherm leegmaken en titel tonen
    Console.Clear();
    Console.WriteLine("==== Add new Smartphone ===\n");

    // Try-catch voor error handling
    // Vangt fouten op bij verkeerde invoer
    try
    {
        // Invoer van gebruiker voor nieuwe smartphone
        // Elke eigenschap wordt apart ingevoerd
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine() ?? string.Empty);  // Converteer naar int

        Console.Write("Enter Brand: ");
        string brand  = Console.ReadLine() ?? string.Empty;      // Merk (Apple, Samsung, etc.)

        Console.Write("Enter Type: ");
        string type  = Console.ReadLine() ?? string.Empty;       // Type (iPhone 14, Galaxy S23, etc.)

        Console.Write("Enter the Release Year: ");
        int releaseyear = int.Parse(Console.ReadLine() ?? string.Empty);  // Jaar van uitgave

        Console.Write("Enter the start price: ");
        int startprice = int.Parse(Console.ReadLine() ?? string.Empty);   // Startprijs

        Console.Write("Enter Operating System: ");
        string operatingsystem  = Console.ReadLine() ?? string.Empty;     // OS (iOS, Android, etc.)

        // Check of de verplichte velden ingevuld zijn
        // Validatie: controleer of belangrijke velden niet leeg zijn
        if(string.IsNullOrWhiteSpace(brand) && 
           string.IsNullOrWhiteSpace(type) && 
           string.IsNullOrWhiteSpace(operatingsystem))
        {
            Console.WriteLine("Brand, type and operating system are required");
        }
        else
        {
            // Maak nieuw SmartPhone object via object initializer
            // Object initializer syntax: direct properties instellen
            var newSmartPhone = new SmartPhone
            {
                Id = id,                    // Uniek ID
                Brand = brand,              // Merk
                Type = type,                // Type
                ReleaseYear = releaseyear,  // Uitgave jaar
                StartPrice = startprice,    // Startprijs
                OperatingSystem = operatingsystem  // Besturingssysteem
            };

            // Voeg toe via service
            // Service layer zorgt voor business logic en data opslag
            smartPhoneService.AddSmartPhone(newSmartPhone);
            Console.WriteLine("\nSmartphone added successfully!");
        }
    }
    catch (Exception ex)
    {
        // Foutafhandeling bij verkeerde invoer
        // Toon foutmelding aan gebruiker
        Console.WriteLine($"Error adding smartphone: {ex.Message}");
    }

    // Wacht op gebruiker om door te gaan
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
}

// ---------------------------
// Methode 3: Zoek smartphone op merk
// ---------------------------
// Doel: Zoekt een smartphone op basis van merk
// Bevat: Null checking en safe navigation
static void GetSmartPhoneByBrand(SmartPhoneService smartPhoneService)
{
    // Scherm leegmaken en titel tonen
    Console.Clear();
    Console.WriteLine("====== Search smartphone by brand ====\n");

    // Vraag gebruiker om merk in te voeren
    Console.Write("Enter the smartphone brand: ");
    string? brand = Console.ReadLine();  // Nullable string voor veiligheid

    // Controleer of brand niet leeg is
    if(!string.IsNullOrEmpty(brand))
    {
        // Zoek via service
        // Service layer gebruikt repository om te zoeken
        var smartphone = smartPhoneService.GetSmartPhoneByBrand(brand);

        // Controleer of smartphone gevonden is
        if (smartphone != null)
        {
            Console.WriteLine($"\nFound smartphone:");
            Console.WriteLine(smartphone);  // ToString() wordt aangeroepen
        }
        else
        {
            Console.WriteLine($"\nNo smartphone found with brand {brand}");
        }
    }
    else
    {
        Console.WriteLine("Invalid brand format.");
    }

    // Wacht op gebruiker om door te gaan
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
}

// ---------------------------
// Methode 4: Zoek smartphone op type
// ---------------------------
// Doel: Zoekt een smartphone op basis van type
// Vergelijkbaar met brand zoeken maar voor type
static void GetSmartPhoneByType(SmartPhoneService smartPhoneService)
{
    // Scherm leegmaken en titel tonen
    Console.Clear();
    Console.WriteLine("====== Search smartphone by type ====\n");

    // Vraag gebruiker om type in te voeren
    Console.Write("Enter the smartphone type: ");
    string? type = Console.ReadLine();  // Nullable string voor veiligheid

    // Controleer of type niet leeg is
    if(!string.IsNullOrEmpty(type))
    {
        // Zoek via service layer
        var smartphone = smartPhoneService.GetSmartPhoneByType(type);

        // Controleer of smartphone gevonden is
        if (smartphone != null)
        {
            Console.WriteLine($"\nFound smartphone:");
            Console.WriteLine(smartphone);  // ToString() wordt aangeroepen
        }
        else
        {
            Console.WriteLine($"\nNo smartphone found with type {type}");
        }
    }
    else
    {
        Console.WriteLine("Invalid type format.");
    }

    // Wacht op gebruiker om door te gaan
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
}

// ---------------------------
// Methode 5: Zoek smartphone op ID
// ---------------------------
// Doel: Zoekt een smartphone op basis van uniek ID
// Bevat: TryParse voor veilige integer conversie
static void GetSmartPhoneById(SmartPhoneService smartPhoneService)
{
    // Scherm leegmaken en titel tonen
    Console.Clear();
    Console.WriteLine("====== Search smartphone by ID ====\n");

    // Vraag gebruiker om ID in te voeren
    Console.Write("Enter the smartphone ID: ");

    // Gebruik TryParse om foutieve invoer te vermijden
    // TryParse: probeert string naar int te converteren, geeft false als het mislukt
    if(int.TryParse(Console.ReadLine(), out int id))
    {
        // Zoek via service layer
        var smartphone = smartPhoneService.GetSmartPhoneById(id);

        // Controleer of smartphone gevonden is
        if (smartphone != null)
        {
            Console.WriteLine($"\nFound smartphone:");
            Console.WriteLine(smartphone);  // ToString() wordt aangeroepen
        }
        else
        {
            Console.WriteLine($"\nNo smartphone found with ID {id}");
        }
    }
    else
    {
        // Foutmelding bij ongeldige ID invoer
        Console.WriteLine("Invalid ID format.");
    }

    // Wacht op gebruiker om door te gaan
    Console.WriteLine("\nPress Enter to continue...");
    Console.ReadLine();
}
