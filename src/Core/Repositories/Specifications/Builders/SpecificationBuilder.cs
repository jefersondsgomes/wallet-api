using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories.Specifications.Builders;

internal class SpecificationBuilder<TEntity> where TEntity : Entity
{
    internal List<Expression<Func<TEntity, object>>> Includes = [];
    internal Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy;
    internal int? Limit;
    internal int? Skip;

    internal static SpecificationBuilder<TEntity> Create()
    {
        return new SpecificationBuilder<TEntity>();
    }

    internal SpecificationBuilder<TEntity> AddInclude(Expression<Func<TEntity, object>> include)
    {
        Includes.Add(include);

        return this;
    }

    internal SpecificationBuilder<TEntity> AddIncludes(List<Expression<Func<TEntity, object>>> includes)
    {
        Includes.AddRange(includes);

        return this;
    }

    internal SpecificationBuilder<TEntity> AddSorting(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
    {
        OrderBy = orderBy;

        return this;
    }

    internal SpecificationBuilder<TEntity> AddPaging(int? limit, int? skip)
    {
        Limit = limit;
        Skip = skip;

        return this;
    }

    internal SpecificationSelectBuilder<TEntity, TSelect> AddSelection<TSelect>(Expression<Func<TEntity, TSelect>> select)
    {
        var specification = new SpecificationSelectBuilder<TEntity, TSelect>(this);

        specification.AddSelection(select);

        return specification;
    }

    internal Specification<TEntity> Build()
    {
        var specification = new Specification<TEntity>(
            Includes,
            OrderBy,
            Limit,
            Skip);

        return specification;
    }
}
