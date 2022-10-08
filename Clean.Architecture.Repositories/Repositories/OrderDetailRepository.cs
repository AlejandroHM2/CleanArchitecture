using Clean.Architecture.Entities.Interfaces;
using Clean.Architecture.Entities.POCO;
using Clean.Architecture.Repositories.DataContext;

namespace Clean.Architecture.Repositories.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly CleanArchitectureContext context;
        public OrderDetailRepository(CleanArchitectureContext context)
            => this.context = context;

        public void Create(OrderDetail orderDetail)
            => context.Add(orderDetail);
    }
}
