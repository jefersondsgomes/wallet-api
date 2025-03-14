using Core.Entities.Enums;

namespace Core.Services.DTOs;

public record ProcessTransactionInput
{
    public int UserId { get; init; }
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public int? TargetWalletId { get; init; }
}
