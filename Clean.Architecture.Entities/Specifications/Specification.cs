using System.Linq.Expressions;

namespace Clean.Architecture.Entities.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> Expression { get; set; }
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = Expression.Compile();
            return predicate(entity);
        }
    }
}
