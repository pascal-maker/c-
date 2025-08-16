namespace CustomExceptionExample.Models;

// Simple bank account model
public class BankAccount
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public string AccountHolder { get; set; }

    public BankAccount(string accountNumber, decimal initialBalance, string accountHolder)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        AccountHolder = accountHolder;
    }
}
