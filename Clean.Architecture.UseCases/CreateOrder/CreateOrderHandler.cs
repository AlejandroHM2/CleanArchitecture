using Clean.Architecture.Entities.Enum;
using Clean.Architecture.Entities.Exceptions;
using Clean.Architecture.Entities.Interfaces;
using Clean.Architecture.Entities.POCO;
using MediatR;

namespace Clean.Architecture.UseCases.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, int>
    {
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUnitOfWork unitOfWork;

        public CreateOrderHandler(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork) =>
            (this.orderRepository, this.orderDetailRepository, this.unitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);

        public async Task<int> Handle(
            CreateOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = new Order()
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = ShippingType.Road,
                DiscountType = DiscountType.Percentege,
                Discount = 10
            };
            orderRepository.Create(order);
            foreach (var detail in request.OrderDetails)
            {
                orderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = order,
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        UnitPrice = detail.UnitPrice
                    });
            }
            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden",
                    ex.Message);
            }
            return order.Id;
        }
    }
}
