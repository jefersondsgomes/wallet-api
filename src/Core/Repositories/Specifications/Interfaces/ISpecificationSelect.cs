using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories.Specifications.Interfaces;

public interface ISpecificationSelect<TEntity, TSelect> : ISpecification<TEntity> where TEntity : Entity
{
    Expression<Func<TEntity, TSelect>> Select { get; }
}
