using Core.Entities;
using Core.Repositories.Specifications.Interfaces;
using System.Linq.Expressions;

namespace Core.Repositories.Specifications;

public class Specification<TEntity>(
    List<Expression<Func<TEntity, object>>>? includes = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    int? limit = null,
    int? skip = null) : ISpecification<TEntity> where TEntity : Entity
{
    public List<Expression<Func<TEntity, object>>> Includes { get; private set; } = includes ?? [];
    public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; private set; } = orderBy;
    public int? Limit { get; private set; } = limit;
    public int? Skip { get; private set; } = skip;
}
