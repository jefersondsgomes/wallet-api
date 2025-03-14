using Core.Entities;
using Core.Repositories.Interfaces;
using Core.Repositories.Specifications.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity>(ApplicationContext context)
    : IRepositoryBase<TEntity> where TEntity : Entity
{
    protected readonly ApplicationContext _context = context;
    protected readonly DbSet<TEntity> _set = context.Set<TEntity>();

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var response = await _set.AddAsync(entity, cancellationToken);

        await SaveChangesAsync(cancellationToken);

        return response.Entity;
    }

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _set
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

        return entity;
    }

    public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var entities = await _set
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public async Task<List<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken)
    {
        var entities = await _set
            .AsNoTracking()
            .Where(predicate)
            .WithSpeficication(specification)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public async Task<List<TSelect>> GetAsync<TSelect>(
        Expression<Func<TEntity, bool>> predicate,
        ISpecificationSelect<TEntity, TSelect> specification,
        CancellationToken cancellationToken)
    {
        var entities = await _set
            .AsNoTracking()
            .Where(predicate)
            .WithSpeficicationSelection(specification)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _set.Entry(entity).State = EntityState.Modified;

        await SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _set.FindAsync([id], cancellationToken);

        if (entity is null)
        {
            return;
        }

        _set.Entry(entity).State = EntityState.Deleted;

        await SaveChangesAsync(cancellationToken);
    }

    private async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _ = await _context.SaveChangesAsync(cancellationToken);
    }
}
