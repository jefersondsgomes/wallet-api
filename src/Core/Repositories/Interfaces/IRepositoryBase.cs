using Core.Entities;
using Core.Repositories.Specifications.Interfaces;
using System.Linq.Expressions;

namespace Core.Repositories.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<List<TSelect>> GetAsync<TSelect>(Expression<Func<TEntity, bool>> predicate, ISpecificationSelect<TEntity, TSelect> specification, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
