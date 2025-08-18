using CustomExceptionExample.Exceptions;
using CustomExceptionExample.Models;
using CustomExceptionExample.Services;

namespace CustomExceptionExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Custom Exception Example ===\n");
        
        // Create instances of our services
        var bankService = new BankService();
        var userService = new UserService();
        var inventoryService = new InventoryService();
        
        // Demonstrate different exception scenarios
        DemonstrateBankExceptions(bankService);
        DemonstrateUserExceptions(userService);
        DemonstrateInventoryExceptions(inventoryService);
        DemonstrateBuiltInExceptions();
        
        Console.WriteLine("\n=== Exception Demonstration Complete ===");
    }
    
    static void DemonstrateBankExceptions(BankService bankService)
    {
        Console.WriteLine("--- Bank Service Exceptions ---");
        
        try
        {
            // Test insufficient funds exception
            Console.WriteLine("Attempting to withdraw $1000 from account with $500...");
            bankService.WithdrawMoney("ACC001", 1000m);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"❌ InsufficientFundsException: {ex.Message}");
            Console.WriteLine($"   Account: {ex.AccountNumber}, Balance: ${ex.CurrentBalance}, Requested: ${ex.RequestedAmount}");
        }
        
        try
        {
            // Test invalid account exception
            Console.WriteLine("\nAttempting to access non-existent account...");
            bankService.GetAccountBalance("INVALID_ACC");
        }
        catch (InvalidAccountException ex)
        {
            Console.WriteLine($"❌ InvalidAccountException: {ex.Message}");
            Console.WriteLine($"   Invalid Account Number: {ex.AccountNumber}");
        }
        
        try
        {
            // Test negative amount exception
            Console.WriteLine("\nAttempting to deposit negative amount...");
            bankService.DepositMoney("ACC001", -100m);
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"❌ InvalidAmountException: {ex.Message}");
            Console.WriteLine($"   Invalid Amount: ${ex.Amount}");
        }
        
        Console.WriteLine();
    }
    
    static void DemonstrateUserExceptions(UserService userService)
    {
        Console.WriteLine("--- User Service Exceptions ---");
        
        try
        {
            // Test invalid age exception
            Console.WriteLine("Attempting to create user with invalid age...");
            userService.CreateUser("John", "john@email.com", 5);
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine($"❌ InvalidAgeException: {ex.Message}");
            Console.WriteLine($"   Provided Age: {ex.Age}, Minimum Required: {ex.MinimumAge}");
        }
        
        try
        {
            // Test duplicate email exception
            Console.WriteLine("\nAttempting to create user with duplicate email...");
            userService.CreateUser("Jane", "john@email.com", 25);
        }
        catch (DuplicateEmailException ex)
        {
            Console.WriteLine($"❌ DuplicateEmailException: {ex.Message}");
            Console.WriteLine($"   Duplicate Email: {ex.Email}");
        }
        
        try
        {
            // Test invalid email format exception
            Console.WriteLine("\nAttempting to create user with invalid email...");
            userService.CreateUser("Bob", "invalid-email", 30);
        }
        catch (InvalidEmailFormatException ex)
        {
            Console.WriteLine($"❌ InvalidEmailFormatException: {ex.Message}");
            Console.WriteLine($"   Invalid Email: {ex.Email}");
        }
        
        Console.WriteLine();
    }
    
    static void DemonstrateInventoryExceptions(InventoryService inventoryService)
    {
        Console.WriteLine("--- Inventory Service Exceptions ---");
        
        try
        {
            // Test out of stock exception
            Console.WriteLine("Attempting to purchase item that's out of stock...");
            inventoryService.PurchaseItem("LAPTOP001", 5);
        }
        catch (OutOfStockException ex)
        {
            Console.WriteLine($"❌ OutOfStockException: {ex.Message}");
            Console.WriteLine($"   Item: {ex.ItemId}, Available: {ex.AvailableQuantity}, Requested: {ex.RequestedQuantity}");
        }
        
        try
        {
            // Test invalid quantity exception
            Console.WriteLine("\nAttempting to purchase negative quantity...");
            inventoryService.PurchaseItem("LAPTOP001", -2);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"❌ InvalidQuantityException: {ex.Message}");
            Console.WriteLine($"   Invalid Quantity: {ex.Quantity}");
        }
        
        try
        {
            // Test item not found exception
            Console.WriteLine("\nAttempting to purchase non-existent item...");
            inventoryService.PurchaseItem("NONEXISTENT", 1);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"❌ ItemNotFoundException: {ex.Message}");
            Console.WriteLine($"   Item ID: {ex.ItemId}");
        }
        
        Console.WriteLine();
    }
    
    static void DemonstrateBuiltInExceptions()
    {
        Console.WriteLine("--- Built-in Exception Examples ---");
        
        try
        {
            // Demonstrate NullReferenceException
            Console.WriteLine("Attempting to access null object...");
            string? nullString = null;
            Console.WriteLine(nullString.Length); // This will throw NullReferenceException
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"❌ NullReferenceException: {ex.Message}");
        }
        
        try
        {
            // Demonstrate ArgumentException
            Console.WriteLine("\nAttempting to parse invalid number...");
            int number = int.Parse("not-a-number");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"❌ FormatException: {ex.Message}");
        }
        
        try
        {
            // Demonstrate IndexOutOfRangeException
            Console.WriteLine("\nAttempting to access array index out of bounds...");
            int[] numbers = { 1, 2, 3 };
            Console.WriteLine(numbers[10]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"❌ IndexOutOfRangeException: {ex.Message}");
        }
        
        try
        {
            // Demonstrate DivideByZeroException
            Console.WriteLine("\nAttempting to divide by zero...");
            int result = 10 / 0;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"❌ DivideByZeroException: {ex.Message}");
        }
        
        Console.WriteLine();
    }
}
