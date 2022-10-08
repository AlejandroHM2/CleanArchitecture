using Clean.Architecture.DTOs.CreateOrder;
using Clean.Architecture.Presenters;
using Clean.Architecture.UseCases.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator mediator;
        public OrderController(IMediator mediator)
        => this.mediator = mediator;

        [HttpPost]
        public async Task<string> CreateAsync(CreateOrderDto order)
        {
            CreateOrderPresenter presenter = new();
            await mediator.Send(new CreateOrderInputPort(order, presenter));
            return presenter.Content;
        }
    }
}