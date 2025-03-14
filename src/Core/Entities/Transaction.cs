using Core.Entities.Enums;

namespace Core.Entities;

public class Transaction(
    int walletId,
    decimal amount,
    string? description,
    TransactionType type) : Entity
{
    public int WalletId { get; set; } = walletId;
    public decimal Amount { get; set; } = amount;
    public string? Description { get; set; } = description;
    public TransactionType Type { get; set; } = type;

    public Wallet? Wallet { get; set; }
    public int? TargetWalletId { get; set; }
    public Wallet? TargetWallet { get; set; }
}
