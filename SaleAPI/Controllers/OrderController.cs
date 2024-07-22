using Application.CustomerCRUD.Commands.Add;
using Application.OrderCRUD.Commands.Add;
using Application.OrderCRUD.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// CreateProduct
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/addOrder")]
        public async Task<IActionResult> CreateOrder(AddOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }
        /// <summary>
        /// UpdateOrder
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/updateorder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
