# Exercise 3 Tutorial: Custom Exceptions and Data Validation

## 📋 Exercise Overview
This exercise demonstrates how to implement custom exceptions and data validation in C#. The goal is to create a beer management system that validates beer data and throws custom exceptions when invalid data is encountered.

## 🎯 Learning Objectives
- Understand custom exception creation
- Implement data validation
- Handle exceptions properly
- Work with CSV file parsing
- Apply separation of concerns (Repository pattern)

## 🏗️ Architecture Overview

```
Exercise 3 Structure:
├── Program.cs                 # Main application entry point
├── Models/
│   └── Beer.cs              # Beer entity with validation
├── CustomExceptions/
│   └── BeerExceptions.cs    # Custom exception class
├── Repository/
│   └── BeerRepository.cs    # Data access layer
├── Service/
│   └── BeerService.cs       # Business logic layer
└── data/
    └── bieren.csv           # Data source
```

## 🔧 Step-by-Step Implementation

### Step 1: Create Custom Exception Class

**File: `CustomExceptions/BeerExceptions.cs`**

```csharp
using System;

namespace beer.Exceptions;

public class Beerexception : Exception
{  
    public string WrongFieldName { get; set; }
    public string WrongValue { get; set; }

    public Beerexception(string message, string fieldName, string fieldValue) : base(message)
    {
        WrongFieldName = fieldName;
        WrongValue = fieldValue;
    }
}
```

**Key Concepts:**
- **Inheritance**: Custom exceptions inherit from `Exception` base class
- **Properties**: Store additional context about the error (field name and value)
- **Constructor**: Call base constructor with error message and set custom properties

### Step 2: Create Beer Model with Validation

**File: `Models/Beer.cs`**

```csharp
using System;
using beer.Exceptions;

namespace beer.Models;

public class Beer
{
    public string Name { get; set; }
    public string Brewery { get; set; }
    public decimal AlcoholPercentage { get; set; }
    public string Color { get; set; }

    public Beer(string name, string brewery, decimal alcoholpercentage, string color)
    {
        // Validate name
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Beerexception("name cannot be empty.", nameof(name), name ?? string.Empty);
        }

        // Validate brewery
        if (string.IsNullOrWhiteSpace(brewery))
        {
            throw new Beerexception("Brewery cannot be empty.", nameof(brewery), brewery ?? string.Empty);
        }

        // Validate alcohol percentage
        if (alcoholpercentage < 0)
        {
            throw new Beerexception("alcohol percentage cannot be negative.", nameof(alcoholpercentage), alcoholpercentage.ToString());
        }

        // Validate color
        if (string.IsNullOrWhiteSpace(color))
        {
            throw new Beerexception("color cannot be empty.", nameof(color), color ?? string.Empty);
        }

        // Assign validated values
        Name = name;
        Brewery = brewery;
        AlcoholPercentage = alcoholpercentage;
        Color = color;
    }

    public override string ToString()
    {
        return $" Name:{Name},Brewery:{Brewery}, AlcoholPercentage:{AlcoholPercentage},Color:{Color}";
    }
}
```

**Validation Rules:**
- **Name**: Cannot be null, empty, or whitespace
- **Brewery**: Cannot be null, empty, or whitespace
- **Alcohol Percentage**: Must be non-negative
- **Color**: Cannot be null, empty, or whitespace

**Key Concepts:**
- **Constructor Validation**: Validate all parameters before assignment
- **nameof()**: Get the parameter name as a string for error reporting
- **Null Coalescing**: Use `??` to provide default values
- **ToString() Override**: Custom string representation

### Step 3: Create Repository Layer

**File: `Repository/BeerRepository.cs`**

```csharp
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using beer.Exceptions;
using beer.Models;

namespace beer.Repositories
{
    public class BeerRepository
    {
        private readonly string _filePath;
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        public BeerRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Beer> GetAllBeers()
        {
            var beers = new List<Beer>();
            
            // Check if file exists
            if (!File.Exists(_filePath)) return beers;

            // Read all lines and skip header
            var lines = File.ReadAllLines(_filePath).Skip(1);

            foreach (var line in lines)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                // Split by semicolon
                var parts = line.Split(';');
                if (parts.Length < 5) continue;

                // Extract data
                var name = parts[1].Trim();
                var brewery = parts[2].Trim();
                var color = parts[3].Trim();
                var alcoholStr = parts[4].Trim().Replace(',', '.');

                // Parse alcohol percentage
                if (!decimal.TryParse(alcoholStr, NumberStyles.Any, Inv, out var alcohol)) continue;

                try
                {
                    beers.Add(new Beer(name, brewery, alcohol, color));
                }
                catch (Beerexception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} (Field: {ex.WrongFieldName}, Value: {ex.WrongValue})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error parsing beer: {ex.Message}");
                }
            }
            return beers;
        }
    }
}
```

**Key Concepts:**
- **File Operations**: Read CSV file line by line
- **Data Parsing**: Split lines and extract values
- **Culture Info**: Handle decimal parsing with different formats
- **Exception Handling**: Catch both custom and general exceptions
- **Graceful Degradation**: Continue processing even if some records fail

### Step 4: Create Service Layer

**File: `Service/BeerService.cs`**

```csharp
using System;
using System.Collections.Generic;
using beer.Exceptions;
using beer.Models;
using beer.Repositories;

namespace beer.Services
{
    public class BeerService
    {
        private readonly BeerRepository _repo;
        
        public BeerService(BeerRepository repo)
        {
            _repo = repo;
        }

        public List<Beer> GetAllBeers()
        {
            return _repo.GetAllBeers();
        }
    }
}
```

**Key Concepts:**
- **Dependency Injection**: Repository is injected through constructor
- **Separation of Concerns**: Service layer handles business logic
- **Delegation**: Service delegates data access to repository

### Step 5: Create Main Program

**File: `Program.cs`**

```csharp
using System;
using System.Collections.Generic;
using beer.Exceptions;

namespace beer.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var beers = new List<Beer>();

            // Test custom exceptions with invalid data
            try 
            { 
                beers.Add(new Beer("jupla", "delirium", -1.0m, "yellow")); 
            }
            catch (Beerexception ex) 
            { 
                Console.WriteLine($"Invalid beer: {ex.Message}"); 
            }

            try 
            { 
                beers.Add(new Beer("yessbeer", "stella", 8.0m, "blond")); 
            }
            catch (Beerexception ex) 
            { 
                Console.WriteLine($"Invalid beer: {ex.Message}"); 
            }

            try 
            { 
                beers.Add(new Beer("Kriek", "stekka", -7.0m, "yellow")); 
            }
            catch (Beerexception ex) 
            { 
                Console.WriteLine($"Invalid beer: {ex.Message}"); 
            }

            // Display valid beers
            foreach (var beer in beers)
            {
                Console.WriteLine(beer);
                Console.WriteLine();
            }
        }
    }
}
```

**Key Concepts:**
- **Try-Catch Blocks**: Handle exceptions gracefully
- **Exception Testing**: Test different validation scenarios
- **User Feedback**: Display meaningful error messages

## 🎓 Important Concepts Explained

### 1. Custom Exceptions
```csharp
public class Beerexception : Exception
{
    public string WrongFieldName { get; set; }
    public string WrongValue { get; set; }
}
```
- **Purpose**: Provide specific error information
- **Benefits**: Better error handling and debugging
- **Usage**: Throw when validation fails

### 2. Data Validation
```csharp
if (string.IsNullOrWhiteSpace(name))
{
    throw new Beerexception("name cannot be empty.", nameof(name), name ?? string.Empty);
}
```
- **Validation Types**: Null checks, range validation, format validation
- **Error Context**: Include field name and invalid value
- **Fail Fast**: Throw exception immediately when validation fails

### 3. Exception Handling
```csharp
try
{
    // Risky operation
}
catch (SpecificException ex)
{
    // Handle specific exception
}
catch (Exception ex)
{
    // Handle general exceptions
}
```
- **Specific First**: Catch specific exceptions before general ones
- **Graceful Handling**: Don't crash the application
- **Logging**: Record errors for debugging

### 4. Repository Pattern
```csharp
public class BeerRepository
{
    private readonly string _filePath;
    
    public List<Beer> GetAllBeers()
    {
        // Data access logic
    }
}
```
- **Separation**: Isolate data access from business logic
- **Testability**: Easy to mock for unit testing
- **Maintainability**: Centralized data access logic

## 🚀 Best Practices

### 1. Exception Design
- ✅ Inherit from appropriate base exception
- ✅ Include relevant context information
- ✅ Use descriptive error messages
- ❌ Don't use exceptions for flow control
- ❌ Don't catch and ignore exceptions

### 2. Validation
- ✅ Validate early (in constructor)
- ✅ Provide clear error messages
- ✅ Include field names in errors
- ✅ Use appropriate validation methods
- ❌ Don't validate the same thing multiple times

### 3. File Handling
- ✅ Check if file exists before reading
- ✅ Handle different data formats
- ✅ Use appropriate encoding
- ✅ Close file handles properly
- ❌ Don't assume file structure

### 4. Code Organization
- ✅ Use meaningful namespaces
- ✅ Separate concerns (Model, Repository, Service)
- ✅ Use dependency injection
- ✅ Keep methods focused and small
- ❌ Don't mix business logic with data access

## 🧪 Testing Scenarios

### Valid Data
```csharp
var beer = new Beer("Heineken", "Heineken", 5.0m, "Blonde");
// Should create successfully
```

### Invalid Data
```csharp
// Empty name
var beer = new Beer("", "Brewery", 5.0m, "Blonde");
// Throws: "name cannot be empty."

// Negative alcohol
var beer = new Beer("Beer", "Brewery", -1.0m, "Blonde");
// Throws: "alcohol percentage cannot be negative."

// Null brewery
var beer = new Beer("Beer", null, 5.0m, "Blonde");
// Throws: "Brewery cannot be empty."
```

## 🔍 Common Pitfalls

1. **Forgetting to validate**: Always validate input data
2. **Poor error messages**: Make errors descriptive and actionable
3. **Not handling exceptions**: Always catch and handle exceptions appropriately
4. **Mixing concerns**: Keep data access, business logic, and presentation separate
5. **Hard-coded values**: Use constants or configuration for file paths and validation rules

## 📚 Additional Resources

- [C# Exception Handling](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)
- [Custom Exceptions](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/)
- [Repository Pattern](https://martinfowler.com/eaaCatalog/repository.html)
- [Data Validation](https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-strings)

## 🎯 Exercise Summary

This exercise teaches:
1. **Custom Exception Creation**: How to create meaningful exceptions
2. **Data Validation**: Proper input validation techniques
3. **Exception Handling**: Graceful error handling
4. **File Processing**: Reading and parsing CSV data
5. **Architecture Patterns**: Repository and Service patterns
6. **Best Practices**: Code organization and error management

The solution demonstrates a complete, production-ready approach to handling data validation and custom exceptions in C# applications.
