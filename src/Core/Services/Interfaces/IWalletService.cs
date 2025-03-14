using Core.Entities;
using Core.Services.DTOs;

namespace Core.Services.Interfaces;

public interface IWalletService
{
    Task<Transaction> ProcessTransactionAsync(ProcessTransactionInput input, CancellationToken cancellationToken);
    Task<decimal> GetBalanceAsync(int userId, CancellationToken cancellationToken);
}
