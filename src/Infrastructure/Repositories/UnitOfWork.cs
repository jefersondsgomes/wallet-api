using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UnitOfWork(DbContext context) : IUnitOfWork
{
    private readonly DbContext _context = context;

    public int SaveChangesAsync()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
