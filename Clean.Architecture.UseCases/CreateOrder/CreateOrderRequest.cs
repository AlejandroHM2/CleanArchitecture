using Clean.Architecture.DTOs.CreateOrder;
using MediatR;

namespace Clean.Architecture.UseCases.CreateOrder
{
    public class CreateOrderRequest : CreateOrderDto, IRequest<int>
    {
    }
}
