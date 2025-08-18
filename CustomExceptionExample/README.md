# Custom Exception Example Exercise

## Overview
This exercise demonstrates how to create and use custom exceptions in C#. It shows both built-in exceptions and custom business rule exceptions in a practical application context.

## Learning Objectives
- Understand how to create custom exception classes
- Learn when and why to use custom exceptions
- Practice exception handling with try-catch blocks
- See the difference between built-in and custom exceptions
- Understand business rule validation through exceptions

## Project Structure
```
CustomExceptionExample/
├── Program.cs                    # Main application entry point
├── Exceptions/                   # Custom exception classes
│   ├── BankExceptions.cs        # Banking-related exceptions
│   ├── UserExceptions.cs        # User management exceptions
│   └── InventoryExceptions.cs   # Inventory management exceptions
├── Models/                       # Data models
│   ├── BankAccount.cs           # Bank account model
│   ├── User.cs                  # User model
│   └── InventoryItem.cs         # Inventory item model
├── Services/                     # Business logic services
│   ├── BankService.cs           # Banking operations
│   ├── UserService.cs           # User management
│   └── InventoryService.cs      # Inventory management
└── README.md                     # This file
```

## Custom Exception Classes

### Bank Exceptions
1. **InsufficientFundsException**
   - Thrown when trying to withdraw more money than available
   - Contains account number, current balance, and requested amount

2. **InvalidAccountException**
   - Thrown when accessing non-existent accounts
   - Contains the invalid account number

3. **InvalidAmountException**
   - Thrown when using negative or zero amounts
   - Contains the invalid amount

### User Exceptions
1. **InvalidAgeException**
   - Thrown when creating users under minimum age
   - Contains provided age and minimum required age

2. **DuplicateEmailException**
   - Thrown when creating users with existing email
   - Contains the duplicate email address

3. **InvalidEmailFormatException**
   - Thrown when email format is invalid
   - Contains the invalid email

### Inventory Exceptions
1. **OutOfStockException**
   - Thrown when trying to purchase more items than available
   - Contains item ID, available quantity, and requested quantity

2. **InvalidQuantityException**
   - Thrown when using negative or zero quantities
   - Contains the invalid quantity

3. **ItemNotFoundException**
   - Thrown when accessing non-existent items
   - Contains the invalid item ID

## Built-in Exceptions Demonstrated
- **NullReferenceException**: Accessing null objects
- **FormatException**: Parsing invalid data types
- **IndexOutOfRangeException**: Accessing array bounds
- **DivideByZeroException**: Division by zero

## Key Concepts

### 1. Custom Exception Structure
```csharp
public class CustomException : Exception
{
    // Additional properties for context
    public string SomeProperty { get; }
    
    // Constructor with default message
    public CustomException(string someProperty)
        : base($"Default error message: {someProperty}")
    {
        SomeProperty = someProperty;
    }
    
    // Constructor with custom message
    public CustomException(string message, string someProperty)
        : base(message)
    {
        SomeProperty = someProperty;
    }
}
```

### 2. Exception Handling Pattern
```csharp
try
{
    // Business logic that might throw exceptions
    service.SomeMethod();
}
catch (SpecificException ex)
{
    // Handle specific exception
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine($"Context: {ex.SomeProperty}");
}
catch (Exception ex)
{
    // Handle any other exceptions
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
```

### 3. Business Rule Validation
```csharp
public void SomeBusinessMethod(string input)
{
    // Validate business rules
    if (string.IsNullOrEmpty(input))
    {
        throw new InvalidInputException(input);
    }
    
    if (input.Length < 5)
    {
        throw new InputTooShortException(input, 5);
    }
    
    // Process valid input
    ProcessInput(input);
}
```

## Running the Example

1. **Navigate to the project directory:**
   ```bash
   cd CustomExceptionExample
   ```

2. **Build the project:**
   ```bash
   dotnet build
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

## Expected Output
The application will demonstrate various exception scenarios:

```
=== Custom Exception Example ===

--- Bank Service Exceptions ---
Attempting to withdraw $1000 from account with $500...
❌ InsufficientFundsException: Insufficient funds in account ACC001. Current balance: $500, Requested amount: $1000
   Account: ACC001, Balance: $500, Requested: $1000

Attempting to access non-existent account...
❌ InvalidAccountException: Invalid account number: INVALID_ACC
   Invalid Account Number: INVALID_ACC

Attempting to deposit negative amount...
❌ InvalidAmountException: Invalid amount: $-100. Amount must be positive.
   Invalid Amount: $-100

--- User Service Exceptions ---
Attempting to create user with invalid age...
❌ InvalidAgeException: Invalid age: 5. Minimum required age is 18.
   Provided Age: 5, Minimum Required: 18

[... more exception demonstrations ...]
```

## Best Practices Demonstrated

1. **Meaningful Exception Names**: Exception names clearly indicate what went wrong
2. **Rich Context Information**: Exceptions contain relevant data for debugging
3. **Multiple Constructors**: Support for both default and custom error messages
4. **Business Rule Validation**: Exceptions enforce business logic rules
5. **Proper Exception Hierarchy**: Custom exceptions inherit from base Exception class
6. **Comprehensive Error Handling**: Try-catch blocks handle specific exception types

## When to Use Custom Exceptions

### Use Custom Exceptions When:
- **Business Rule Violations**: When application-specific rules are broken
- **Domain-Specific Errors**: Errors that are meaningful in your application context
- **Rich Error Information**: When you need to include additional context data
- **API Design**: When designing public APIs that need clear error contracts

### Use Built-in Exceptions When:
- **System Errors**: NullReferenceException, IndexOutOfRangeException
- **Framework Errors**: FormatException, ArgumentException
- **Standard Scenarios**: Common programming errors that don't need custom context

## Extension Ideas

1. **Add More Exception Types**: Create exceptions for other business scenarios
2. **Exception Logging**: Add logging functionality to exception handlers
3. **Exception Recovery**: Implement recovery mechanisms for certain exceptions
4. **Exception Aggregation**: Create composite exceptions for multiple errors
5. **Internationalization**: Add support for localized error messages

This exercise provides a solid foundation for understanding and implementing custom exceptions in real-world applications.

