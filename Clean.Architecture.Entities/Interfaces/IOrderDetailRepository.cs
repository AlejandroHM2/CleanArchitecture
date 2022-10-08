using Clean.Architecture.Entities.POCO;

namespace Clean.Architecture.Entities.Interfaces
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
    }
}
