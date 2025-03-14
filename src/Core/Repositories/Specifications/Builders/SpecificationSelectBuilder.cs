using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories.Specifications.Builders;

internal class SpecificationSelectBuilder<TEntity, TSelect> : SpecificationBuilder<TEntity> where TEntity : Entity
{
    internal Expression<Func<TEntity, TSelect>>? Select;

    internal SpecificationSelectBuilder(SpecificationBuilder<TEntity> specification)
    {
        Includes = specification.Includes;
        OrderBy = specification.OrderBy;
        Limit = specification.Limit;
        Skip = specification.Skip;
    }

    internal SpecificationSelectBuilder<TEntity, TSelect> AddSelection(Expression<Func<TEntity, TSelect>> select)
    {
        Select = select;

        return this;
    }

    internal new SpecificationSelect<TEntity, TSelect> Build()
    {
        return new SpecificationSelect<TEntity, TSelect>(
            Select,
            Includes,
            OrderBy,
            Limit,
            Skip);
    }
}
