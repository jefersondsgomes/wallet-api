using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories.Specifications.Interfaces;

public interface ISpecification<TEntity> where TEntity : Entity
{
    List<Expression<Func<TEntity, object>>> Includes { get; }
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; }
    int? Limit { get; }
    int? Skip { get; }
}
