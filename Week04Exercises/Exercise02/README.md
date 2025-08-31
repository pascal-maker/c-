# 📚 Course Management System

Een console-gebaseerd cursus management systeem geschreven in C# voor het beheren van studenten en cursussen.

## 🎯 Overzicht

Dit systeem biedt een eenvoudige maar krachtige interface voor:
- **Studenten beheren** (toevoegen, bekijken)
- **Cursussen beheren** (toevoegen, bekijken)
- **Inschrijvingen beheren** (studenten inschrijven voor cursussen)
- **Financiële overzichten** (totale kosten per student)

## 🚀 Installatie

### Vereisten
- **.NET 7.0** of hoger
- **Visual Studio** of **VS Code** (optioneel)

### Stappen
1. **Clone of download** het project
2. **Navigeer** naar de project directory:
   ```bash
   cd Week04Exercises/Exercise02
   ```
3. **Build** het project:
   ```bash
   dotnet build
   ```
4. **Run** het project:
   ```bash
   dotnet run
   ```

## 📖 Gebruik

### Hoofdmenu
Na het starten van het programma zie je het hoofdmenu:

```
Course Management System
1. Add Student
2. Add Course
3. Add Student to Course
4. List Students
5. List Courses
6. List Students in Course
7. Total course price student is enrolled in
99. Exit
```

### Functies

#### 1. 📝 Student Toevoegen
- **Keuze**: `1`
- **Input**: Naam en email
- **Output**: Bevestiging van toevoeging
- **Voorbeeld**:
  ```
  Enter Student Name: John Doe
  Enter Student Email: john@example.com
  Student added successfully!
  ```

#### 2. 📚 Cursus Toevoegen
- **Keuze**: `2`
- **Input**: Naam en prijs
- **Output**: Bevestiging van toevoeging
- **Voorbeeld**:
  ```
  Enter Course Name: C# Programming
  Enter Course Price: 299.99
  Course added successfully!
  ```

#### 3. 🎓 Student Inschrijven voor Cursus
- **Keuze**: `3`
- **Stappen**:
  1. Kies student uit lijst (via ID)
  2. Kies cursus uit lijst (via ID)
- **Output**: Bevestiging van inschrijving
- **Voorbeeld**:
  ```
  Choose a student from the list by its Id
  Id: 1, Name: John Doe, Email: john@example.com
  Enter: 1
  
  Choose a course from the list by its Id
  Id: 1, Name: C# Programming, Price: €299.99
  Enter: 1
  
  Student added to course!
  ```

#### 4. 👥 Studenten Lijst
- **Keuze**: `4`
- **Output**: Overzicht van alle studenten
- **Voorbeeld**:
  ```
  Id: 1, Name: John Doe, Email: john@example.com
  Id: 2, Name: Jane Smith, Email: jane@example.com
  ```

#### 5. 📖 Cursussen Lijst
- **Keuze**: `5`
- **Output**: Overzicht van alle cursussen
- **Voorbeeld**:
  ```
  Id: 1, Name: C# Programming, Price: €299.99
  Id: 2, Name: Java Basics, Price: €249.99
  ```

#### 6. 🎯 Studenten in Cursus
- **Keuze**: `6`
- **Stappen**:
  1. Kies cursus uit lijst (via ID)
- **Output**: Alle studenten in die cursus
- **Voorbeeld**:
  ```
  Id: 1, Name: C# Programming, Price: 299.99
  Enter Course Id: 1
  
  Id: 1, Name: John Doe, Email: john@example.com
  Id: 2, Name: Jane Smith, Email: jane@example.com
  ```

#### 7. 💰 Totale Cursus Prijs per Student
- **Keuze**: `7`
- **Stappen**:
  1. Kies student uit lijst (via ID)
- **Output**: Totale kosten van alle cursussen
- **Voorbeeld**:
  ```
  Choose a student from the list by its Id
  Id: 1, Name: John Doe, Email: john@example.com
  Enter: 1
  
  Total price of courses: €549.98
  ```

#### 8. 🚪 Afsluiten
- **Keuze**: `99`
- **Output**: "Exiting" en programma stopt

## 🏗️ Architectuur

### Project Structuur
```
Exercise02/
├── Models/
│   ├── Student.cs          # Student model
│   └── Course.cs           # Cursus model
├── Service/
│   └── CourseManagement.cs # Hoofdservice
├── Program.cs              # Entry point
└── README.md               # Deze handleiding
```

### Klassen

#### 📋 Student Model
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Course> Courses { get; set; }
}
```

#### 📚 Course Model
```csharp
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<Student> Students { get; set; }
}
```

#### ⚙️ CourseManagement Service
- **Verantwoordelijkheid**: Business logic en user interface
- **Data Storage**: In-memory lijsten
- **Pattern**: Service Layer Pattern

## 🔧 Technische Details

### Data Types
- **ID**: `int` (auto-generated)
- **Price**: `decimal` (precisie voor geld)
- **Names/Email**: `string`
- **Collections**: `List<T>`

### LINQ Gebruik
- **FirstOrDefault()**: Veilige object zoeken
- **Sum()**: Totale prijs berekening
- **ForEach()**: Lijsten doorlopen

### Error Handling
- **Null checks**: Voorkomt crashes
- **User feedback**: Duidelijke berichten
- **Input validation**: Basis validatie

## 🎨 Features

### ✅ Implemented
- [x] Student toevoegen
- [x] Cursus toevoegen
- [x] Student inschrijven voor cursus
- [x] Studenten lijst bekijken
- [x] Cursussen lijst bekijken
- [x] Studenten in cursus bekijken
- [x] Totale prijs berekenen
- [x] In-memory data storage
- [x] Auto-generated IDs
- [x] Many-to-many relaties

### 🔮 Mogelijke Uitbreidingen
- [ ] Data persistence (database/CSV)
- [ ] Student/cursus verwijderen
- [ ] Student/cursus bewerken
- [ ] Zoekfunctionaliteit
- [ ] Sortering en filtering
- [ ] Export naar PDF/Excel
- [ ] User authentication
- [ ] Logging systeem

## 🐛 Troubleshooting

### Veelvoorkomende Problemen

#### "Student not found!"
- **Oorzaak**: Student ID bestaat niet
- **Oplossing**: Gebruik een geldig ID uit de lijst

#### "Course not found!"
- **Oorzaak**: Cursus ID bestaat niet
- **Oplossing**: Gebruik een geldig ID uit de lijst

#### Build Errors
- **Oorzaak**: .NET versie incompatibiliteit
- **Oplossing**: Update naar .NET 7.0+ of check `global.json`

#### Runtime Errors
- **Oorzaak**: Ongeldige input (letters waar cijfers verwacht)
- **Oplossing**: Voer alleen geldige waarden in

## 📝 Code Voorbeelden

### Student Toevoegen
```csharp
Student student = new Student() 
{ 
    Id = _students.Count + 1,
    Name = "John Doe", 
    Email = "john@example.com", 
    Courses = new List<Course>() 
};
```

### Cursus Toevoegen
```csharp
Course course = new Course() 
{ 
    Id = _courses.Count + 1,
    Name = "C# Programming", 
    Price = 299.99M,
    Students = new List<Student>() 
};
```

### Totale Prijs Berekening
```csharp
decimal totalPrice = student.Courses.Sum(c => c.Price);
```

## 🤝 Bijdragen

1. **Fork** het project
2. **Maak** een feature branch
3. **Commit** je wijzigingen
4. **Push** naar de branch
5. **Open** een Pull Request

## 📄 Licentie

Dit project is gemaakt voor educatieve doeleinden.

## 👨‍💻 Auteur

Gemaakt als onderdeel van de Advanced Software Engineering cursus.

---

**💡 Tip**: Start altijd met het toevoegen van enkele studenten en cursussen voordat je inschrijvingen probeert te maken!
