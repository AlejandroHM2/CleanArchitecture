using Clean.Architecture.Entities.Interfaces;
using Clean.Architecture.Entities.POCO;
using Clean.Architecture.Entities.Specifications;
using Clean.Architecture.Repositories.DataContext;

namespace Clean.Architecture.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly CleanArchitectureContext context;
        public OrderRepository(CleanArchitectureContext context) => this.context = context;
        
        public void Create(Order order)
            => context.Add(order);

        public IEnumerable<Order> GetOrderBySpecfication(Specification<Order> specification)
        {
            var expresionDelegate = specification.Expression.Compile();
            return context.Order.Where(expresionDelegate);
        }
    }
}
