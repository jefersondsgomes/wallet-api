namespace Core.Repositories.Interfaces;

public interface IUnitOfWork
{
    int SaveChangesAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
