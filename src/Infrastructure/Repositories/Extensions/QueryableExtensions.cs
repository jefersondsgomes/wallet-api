using Core.Entities;
using Core.Repositories.Specifications.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

internal static class QueryableExtensions
{
    internal static IQueryable<TEntity> WithSpeficication<TEntity>(
        this IQueryable<TEntity> entities,
        ISpecification<TEntity> specification) where TEntity : Entity
    {
        var query = entities;

        foreach (var include in specification.Includes)
        {
            query.Include(include);
        }

        if (specification.OrderBy is not null)
        {
            query = specification.OrderBy(query);
        }

        if (specification.Limit.HasValue)
        {
            query = query.Take(specification.Limit.Value);
        }

        if (specification.Skip.HasValue)
        {
            query = query.Skip(specification.Skip.Value);
        }

        return query;
    }

    internal static IQueryable<TSelect> WithSpeficicationSelection<TEntity, TSelect>(
        this IQueryable<TEntity> entities,
        ISpecificationSelect<TEntity, TSelect> specification) where TEntity : Entity
    {
        var select = entities
            .WithSpeficication(specification)
            .Select(specification.Select);

        return select;
    }
}
