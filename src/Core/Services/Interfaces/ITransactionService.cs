using Core.Entities;

namespace Core.Services.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<Transaction>> GetAsync(int userId, CancellationToken cancellationToken);
}
