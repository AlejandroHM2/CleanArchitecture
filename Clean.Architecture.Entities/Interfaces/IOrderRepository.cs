using Clean.Architecture.Entities.POCO;
using Clean.Architecture.Entities.Specifications;

namespace Clean.Architecture.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderBySpecfication(Specification<Order> specification);
    }
}
