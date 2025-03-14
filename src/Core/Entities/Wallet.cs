using Core.Entities.Enums;

namespace Core.Entities;

public class Wallet(decimal balance, int userId) : Entity
{
    public decimal Balance { get; set; } = balance;
    public int UserId { get; set; } = userId;

    public User? User { get; set; }
    public List<Transaction> Transactions { get; set; } = [];

    public void Credit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount, TransactionType type = TransactionType.Withdraw)
    {
        if (amount > Balance)
        {
            // TODO: Create custom exception
            throw new Exception($"the amount to be ${type} is is greater than available");
        }

        Balance -= amount;
    }

    public void Transfer(decimal amount, Wallet targetWallet)
    {
        Withdraw(amount);

        targetWallet.Balance += amount;
    }

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }
}
