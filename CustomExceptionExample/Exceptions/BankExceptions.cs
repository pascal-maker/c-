namespace CustomExceptionExample.Exceptions;

// Custom exception for insufficient funds in a bank account
public class InsufficientFundsException : Exception
{
    // Properties to store additional context information
    public string AccountNumber { get; }
    public decimal CurrentBalance { get; }
    public decimal RequestedAmount { get; }

    // Constructor with detailed information
    public InsufficientFundsException(string accountNumber, decimal currentBalance, decimal requestedAmount)
        : base($"Insufficient funds in account {accountNumber}. Current balance: ${currentBalance}, Requested amount: ${requestedAmount}")
    {
        AccountNumber = accountNumber;
        CurrentBalance = currentBalance;
        RequestedAmount = requestedAmount;
    }

    // Constructor with custom message
    public InsufficientFundsException(string message, string accountNumber, decimal currentBalance, decimal requestedAmount)
        : base(message)
    {
        AccountNumber = accountNumber;
        CurrentBalance = currentBalance;
        RequestedAmount = requestedAmount;
    }
}

// Custom exception for invalid account numbers
public class InvalidAccountException : Exception
{
    public string AccountNumber { get; }

    public InvalidAccountException(string accountNumber)
        : base($"Invalid account number: {accountNumber}")
    {
        AccountNumber = accountNumber;
    }

    public InvalidAccountException(string message, string accountNumber)
        : base(message)
    {
        AccountNumber = accountNumber;
    }
}

// Custom exception for invalid monetary amounts
public class InvalidAmountException : Exception
{
    public decimal Amount { get; }

    public InvalidAmountException(decimal amount)
        : base($"Invalid amount: ${amount}. Amount must be positive.")
    {
        Amount = amount;
    }

    public InvalidAmountException(string message, decimal amount)
        : base(message)
    {
        Amount = amount;
    }
}
