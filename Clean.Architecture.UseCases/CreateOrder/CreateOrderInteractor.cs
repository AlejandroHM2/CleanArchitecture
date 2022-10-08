using Clean.Architecture.Entities.Enum;
using Clean.Architecture.Entities.Exceptions;
using Clean.Architecture.Entities.Interfaces;
using Clean.Architecture.Entities.POCO;
using MediatR;

namespace Clean.Architecture.UseCases.CreateOrder
{
    public class CreateOrderInteractor : AsyncRequestHandler<CreateOrderInputPort>
    {
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUnitOfWork unitOfWork;

        public CreateOrderInteractor(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork) =>
            (this.orderRepository, this.orderDetailRepository, this.unitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);

        protected override async Task Handle(
            CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order order = new()
            {
                CustomerId = request.Data.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.Data.ShipAddress,
                ShipCity = request.Data.ShipCity,
                ShipCountry = request.Data.ShipCountry,
                ShipPostalCode = request.Data.ShipPostalCode,
                ShippingType = ShippingType.Road,
                DiscountType = DiscountType.Percentege,
                Discount = 10
            };
            orderRepository.Create(order);
            foreach (var detail in request.Data.OrderDetails)
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
            request.OutputPort.Handle(order.Id);
        }
    }
}
