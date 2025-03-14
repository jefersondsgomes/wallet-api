using Core.Entities;
using Core.Repositories.Specifications.Interfaces;
using System.Linq.Expressions;

namespace Core.Repositories.Specifications;

public class SpecificationSelect<TEntity, TSelect>(
    Expression<Func<TEntity, TSelect>>? select,
    List<Expression<Func<TEntity, object>>>? includes = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    int? limit = null,
    int? skip = null) : Specification<TEntity>(includes, orderBy, limit, skip), ISpecificationSelect<TEntity, TSelect> where TEntity : Entity
{
    // TODO: Create custom exception
    public Expression<Func<TEntity, TSelect>> Select { get; } = select ?? throw new Exception("Select can't be null");
}
