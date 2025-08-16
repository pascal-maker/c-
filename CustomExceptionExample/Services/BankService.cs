using CustomExceptionExample.Exceptions;
using CustomExceptionExample.Models;

namespace CustomExceptionExample.Services;

// Bank service that demonstrates custom exceptions
public class BankService
{
    // Simulated database of bank accounts
    private readonly Dictionary<string, BankAccount> _accounts;

    public BankService()
    {
        // Initialize with some sample accounts
        _accounts = new Dictionary<string, BankAccount>
        {
            { "ACC001", new BankAccount("ACC001", 500m, "John Doe") },
            { "ACC002", new BankAccount("ACC002", 1000m, "Jane Smith") },
            { "ACC003", new BankAccount("ACC003", 2500m, "Bob Johnson") }
        };
    }

    // Method that throws InsufficientFundsException
    public void WithdrawMoney(string accountNumber, decimal amount)
    {
        // Validate amount
        if (amount <= 0)
        {
            throw new InvalidAmountException(amount);
        }

        // Check if account exists
        if (!_accounts.ContainsKey(accountNumber))
        {
            throw new InvalidAccountException(accountNumber);
        }

        var account = _accounts[accountNumber];

        // Check if sufficient funds are available
        if (account.Balance < amount)
        {
            throw new InsufficientFundsException(accountNumber, account.Balance, amount);
        }

        // Process withdrawal
        account.Balance -= amount;
        Console.WriteLine($"✅ Successfully withdrew ${amount} from account {accountNumber}. New balance: ${account.Balance}");
    }

    // Method that throws InvalidAccountException
    public decimal GetAccountBalance(string accountNumber)
    {
        if (!_accounts.ContainsKey(accountNumber))
        {
            throw new InvalidAccountException(accountNumber);
        }

        return _accounts[accountNumber].Balance;
    }

    // Method that throws InvalidAmountException
    public void DepositMoney(string accountNumber, decimal amount)
    {
        // Validate amount
        if (amount <= 0)
        {
            throw new InvalidAmountException(amount);
        }

        // Check if account exists
        if (!_accounts.ContainsKey(accountNumber))
        {
            throw new InvalidAccountException(accountNumber);
        }

        var account = _accounts[accountNumber];
        account.Balance += amount;
        Console.WriteLine($"✅ Successfully deposited ${amount} to account {accountNumber}. New balance: ${account.Balance}");
    }
}
