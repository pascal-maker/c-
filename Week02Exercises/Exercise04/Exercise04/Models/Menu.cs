using menu.Models;                                      // Gebruik de Student en Course modellen uit de namespace menu.Models

public class Menu                                         // Definieert de Menu-klasse die de console-app menu-acties beheert
{
    private List<Student> students = new List<Student>(); // Lijst om Student-objecten tijdelijk op te slaan in geheugen
    private List<Course> courses = new List<Course>();    // Lijst om Course-objecten tijdelijk op te slaan in geheugen

    // Dictionary met als key de Student (object-referentie) en als value de lijst van ingeschreven Courses
    // Let op: keys vergelijken op referentie tenzij Student.Equals/GetHashCode geoverride is
    private Dictionary<Student, List<Course>> studentCourses = new Dictionary<Student, List<Course>>();

    public void Show()                                     // Publieke methode om het hoofdmenu te tonen en te besturen
    {
        while (true)                                       // Oneindige loop tot de gebruiker kiest om te stoppen
        {
            Console.WriteLine("\nCourse Management System"); // Titel van het menu
            Console.WriteLine("1. Add Student");             // Optie 1: Student toevoegen
            Console.WriteLine("2. Add Course");              // Optie 2: Course toevoegen
            Console.WriteLine("3. Add Student to course");   // Optie 3: Student aan Course koppelen
            Console.WriteLine("4. List Students");           // Optie 4: Studenten tonen
            Console.WriteLine("5. List Courses");            // Optie 5: Courses tonen
            Console.WriteLine("6. List Students in Courses");// Optie 6: Toon studenten per gekozen course
            Console.WriteLine("7. Total course price student enrolled in"); // Optie 7: Som van prijzen voor student
            Console.WriteLine("99. Exit");                   // Optie 99: Afsluiten
            Console.Write("Choose an option: ");             // Prompt voor keuze

            var option = Console.ReadLine();                 // Lees de invoer als string
            Console.WriteLine();                             // Lege lijn voor leesbaarheid

            ParseOption(option);                             // Verwerk de gekozen optie
        }
    }

    private void ParseOption(string option)                  // Bepaalt welke actie hoort bij de gekozen optie
    {
        switch (option)                                      // Switch op de tekstuele keuze
        {
            case "1":                                        // Als keuze "1" is
                AddStudent();                                // Roep AddStudent aan
                break;                                       // Stop dit switch-pad
            case "2":                                        // Keuze "2"
                AddCourse();                                 // Roep AddCourse aan
                break;                                       // Stop dit switch-pad
            case "3":                                        // Keuze "3"
                AddStudentToCourse();                        // Roep AddStudentToCourse aan
                break;                                       // Stop dit switch-pad
            case "4":                                        // Keuze "4"
                ListStudents();                              // Roep ListStudents aan
                break;                                       // Stop dit switch-pad
            case "5":                                        // Keuze "5"
                ListCourse();                                // Roep ListCourse aan
                break;                                       // Stop dit switch-pad
            case "6":                                        // Keuze "6"
                ListStudentInCourse();                       // Roep ListStudentInCourse aan
                break;                                       // Stop dit switch-pad
            case "7":                                        // Keuze "7"
                TotalCoursePriceStudent();                   // Roep TotalCoursePriceStudent aan
                break;                                       // Stop dit switch-pad
            case "99":                                       // Keuze "99"
                Console.WriteLine("Goodbye!");               // Print afscheidsbericht
                Environment.Exit(0);                         // Beëindig het programma
                break;                                       // (onbereikbaar, maar netjes)
            default:                                         // Voor alle andere niet-gekende keuzes
                Console.WriteLine("Invalid option. Please choose 1-7."); // Foutmelding
                break;                                       // Stop dit switch-pad
        }
    }

    private void AddStudent()                                // Voegt een nieuwe student toe via console-invoer
    {
        Console.Write("Enter a Name: ");                     // Vraag naam
        string name = Console.ReadLine();                    // Lees naam in

        Console.Write("Enter your email: ");                 // Vraag e-mail
        string email = Console.ReadLine();                   // Lees e-mail in

        Console.Write("Enter your class: ");                 // Vraag klas
        string klas = Console.ReadLine();                    // Lees klas in

        Console.Write("Enter your birthdate: ");             // Vraag geboortedatum (string-formaat)
        string birthdate = Console.ReadLine();               // Lees geboortedatum in

        Student student = new Student(name, email, klas, birthdate); // Maak nieuw Student-object
        students.Add(student);                               // Voeg toe aan de studentenlijst

        Console.WriteLine("Student added.");                 // Bevestiging
    }

    private void AddCourse()                                 // Voegt een nieuwe course toe via console-invoer
    {
        Console.Write("Enter a Course ID: ");                // Vraag numeric ID
        if (!int.TryParse(Console.ReadLine(), out int id))   // Parse veilig naar int (voorkomt crash)
        {
            Console.WriteLine("Invalid ID.");                // Foutmelding bij ongeldige invoer
            return;                                          // Stop methode
        }

        Console.Write("Enter a Course Name: ");              // Vraag naam van de course
        string name = Console.ReadLine();                    // Lees naam in

        Console.Write("Enter your price: ");                 // Vraag prijs (int in dit model)
        if (!int.TryParse(Console.ReadLine(), out int price))// Parse veilig naar int
        {
            Console.WriteLine("Invalid price.");             // Foutmelding bij ongeldige invoer
            return;                                          // Stop methode
        }

        Course course = new Course(id, name, price);         // Maak nieuw Course-object
        courses.Add(course);                                 // Voeg toe aan de courselijst

        Console.WriteLine("Course added.");                  // Bevestiging
    }

    private void AddStudentToCourse()                        // Koppelt een bestaande student aan een bestaande course
    {
        if (students.Count == 0)                             // Controleer of er studenten zijn
        {
            Console.WriteLine("No students yet. Add a student first."); // Informeer gebruiker
            return;                                          // Stop methode
        }
        if (courses.Count == 0)                              // Controleer of er courses zijn
        {
            Console.WriteLine("No courses yet. Add a course first.");   // Informeer gebruiker
            return;                                          // Stop methode
        }

        Console.WriteLine("Select student:");                // Prompt om student te kiezen
        for (int i = 0; i < students.Count; i++)             // Loop door alle studenten
            Console.WriteLine($" {i}. {students[i].Name}");  // Toon index en naam van elke student

        if (!int.TryParse(Console.ReadLine(), out int sIndex) // Lees keuze en parse naar int
            || sIndex < 0 || sIndex >= students.Count)       // Valideer dat index binnen 0..Count-1 ligt
        {
            Console.WriteLine("Invalid student selection.");  // Foutmelding bij ongeldige keuze
            return;                                           // Stop methode
        }
        var selectedStudent = students[sIndex];               // Haal gekozen Student op

        Console.WriteLine("Select course:");                  // Prompt om course te kiezen
        for (int i = 0; i < courses.Count; i++)               // Loop door alle courses
            Console.WriteLine($" {i}. {courses[i].Name}");    // Toon index en naam van elke course

        if (!int.TryParse(Console.ReadLine(), out int cIndex) // Lees keuze en parse naar int
            || cIndex < 0 || cIndex >= courses.Count)         // Valideer dat index binnen 0..Count-1 ligt
        {
            Console.WriteLine("Invalid course selection.");   // Foutmelding bij ongeldige keuze
            return;                                           // Stop methode
        }
        var selectedCourse = courses[cIndex];                 // Haal gekozen Course op

        if (!studentCourses.ContainsKey(selectedStudent))     // Bestaat er al een entry voor deze student?
            studentCourses[selectedStudent] = new List<Course>(); // Zo niet, maak lege lijst

        studentCourses[selectedStudent].Add(selectedCourse);  // Voeg de gekozen course toe voor deze student

        Console.WriteLine("Course added to student");         // Bevestiging
    }


// Controleer of de dictionary studentCourses al een entry heeft voor deze student.
// Dictionary<Student, List<Course>> betekent:
//   Key   = Student
//   Value = Lijst van alle courses die de student volgt.
//
// ContainsKey(selectedStudent) kijkt of er al een lijst bestaat voor deze student.
// Het ! (NOT) betekent: als er géén lijst bestaat voor deze student...
    // ...maak dan een nieuwe lege lijst aan en koppel die aan deze student in de dictionary.
   

// Voeg de gekozen course toe aan de lijst van deze student.
// We weten zeker dat de lijst bestaat (omdat we die zojuist hebben aangemaakt als dat nodig was).

// Laat in de console weten dat de course succesvol is toegevoegd aan de student.


    private void ListStudents()                               // Toont alle studenten en laat eventueel één kiezen
    {
        if (students.Count == 0)                              // Geen studenten aanwezig?
        {
            Console.WriteLine("No students yet.");            // Meld het
            return;                                           // Stop methode
        }

        for (int i = 0; i < students.Count; i++)              // Loop door alle studenten
            Console.WriteLine($"{i}. {students[i].Name} - {students[i].Email}, {students[i].Klas}, {students[i].BirthDate}"); // Toon detail

        Console.Write("Choose a student by number: ");        // Prompt om een studentnummer te kiezen
        if (int.TryParse(Console.ReadLine(), out int index)   // Parse veilig naar int
            && index >= 0 && index < students.Count)          // Controleer grenzen
            Console.WriteLine($"You selected {students[index].Name}"); // Print selectie
        else                                                  // Indien ongeldige invoer
            Console.WriteLine("Invalid selection.");           // Meld fout
    }

    private void ListCourse()                                  // Toont alle courses en laat eventueel één kiezen
    {
        if (courses.Count == 0)                                // Geen courses aanwezig?
        {
            Console.WriteLine("No courses yet.");              // Meld het
            return;                                            // Stop methode
        }

        for (int i = 0; i < courses.Count; i++)                // Loop door alle courses
            Console.WriteLine($"{i}. {courses[i].Name}  {courses[i].Price} EUR"); // Toon index, naam en prijs

        Console.Write("Choose a course by number: ");          // Prompt om een coursenummer te kiezen
        if (int.TryParse(Console.ReadLine(), out int index)    // Parse veilig naar int
            && index >= 0 && index < courses.Count)            // Controleer grenzen
            Console.WriteLine($"You selected: {courses[index].ID} - {courses[index].Name}"); // Print selectie
        else                                                   // Indien ongeldige invoer
            Console.WriteLine("Invalid selection.");            // Meld fout
    }

    private void ListStudentInCourse()                         // Toont alle studenten die in een gekozen course zitten
    {
        if (courses.Count == 0)                                // Geen courses aanwezig?
        {
            Console.WriteLine("No courses yet.");              // Meld het
            return;                                            // Stop methode
        }

        Console.WriteLine("Choose a course:");                 // Prompt om course te kiezen
        for (int i = 0; i < courses.Count; i++)                // Loop door alle courses
            Console.WriteLine($"{i}. {courses[i].Name}");      // Toon index en naam

        if (!int.TryParse(Console.ReadLine(), out int cIndex)  // Parse veilig naar int
            || cIndex < 0 || cIndex >= courses.Count)          // Controleer grenzen
        {
            Console.WriteLine("Invalid course selection.");    // Meld fout
            return;                                            // Stop methode
        }

        Course selectedCourse = courses[cIndex];               // Haal gekozen Course op
        Console.WriteLine($"Students enrolled in {selectedCourse.Name}:"); // Koptekst

        bool any = false;                                      // Houdt bij of we minstens één student vonden

        foreach (var entry in studentCourses)                  // Loop door elke (Student -> List<Course>) in het dictionary
        {
            if (entry.Value.Contains(selectedCourse))          // Kijk of deze student de gekozen course volgt
            {
                Console.WriteLine($"- {entry.Key.Name}");      // Toon de naam van de student (entry.Key is Student)
                any = true;                                    // Markeer dat er minstens één was
            }
        }

        if (!any)                                              // Als geen enkele student gevonden is
            Console.WriteLine("No students enrolled in this course."); // Meld het
    }

    private void TotalCoursePriceStudent()                     // Berekent totale prijs van alle courses voor een gekozen student
    {
        if (students.Count == 0)                               // Geen studenten aanwezig?
        {
            Console.WriteLine("No students yet.");             // Meld het
            return;                                            // Stop methode
        }

        Console.WriteLine("Choose a student:");                // Prompt om student te kiezen
        for (int i = 0; i < students.Count; i++)               // Loop door alle studenten
            Console.WriteLine($"{i}. {students[i].Name}");     // Toon index en naam

        if (int.TryParse(Console.ReadLine(), out int sIndex)   // Parse veilig naar int
            && sIndex >= 0 && sIndex < students.Count)         // Controleer grenzen
        {
            Student selectedStudent = students[sIndex];        // Haal gekozen Student op

            if (studentCourses.TryGetValue(selectedStudent, out var enrolled) // Probeer lijst van courses op te halen
                && enrolled.Count > 0)                         // Controleer of er minstens één course is
            {
                int total = 0;                                 // Totaalprijs (int in dit model)
                foreach (Course c in enrolled)                 // Loop door alle ingeschreven courses
                    total += c.Price;                          // Tel de prijs op bij het totaal

                Console.WriteLine($"Total price for {selectedStudent.Name}'s courses: {total}"); // Toon totaal
            }
            else                                               // Geen entry of lege lijst
            {
                Console.WriteLine("This student is not enrolled in any courses."); // Meld het
            }
        }
        else                                                   // Ongeldige invoer of out-of-range index
        {
            Console.WriteLine("Invalid student selection.");   // Meld fout
        }
    }
}
