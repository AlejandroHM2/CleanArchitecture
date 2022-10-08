using Clean.Architecture.UseCases.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator mediator;
        public OrderController(IMediator mediator)
        => this.mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(
            CreateOrderRequest orderRequest)
        {
            return await mediator.Send(orderRequest);
        }
    }
}
