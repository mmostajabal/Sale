using Application.CustomerCRUD.Commands.Add;
using Application.CustomerCRUD.Queries.Get;
using Application.OrderCRUD.Commands.Add;
using Application.OrderCRUD.Commands.Delete;
using Application.OrderCRUD.Commands.Update;
using Application.OrderCRUD.Queries.GetAllOrderByCustomerId;
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
        [HttpPut("/updateorder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        /// <summary>
        /// DeleteOrder
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("/deleteorder")]
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        /// <summary>
        /// GetAllOrderByCustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("/{customerId}/GetCustomerOrder")]
        public async Task<IActionResult> GetAllOrderByCustomerId(int customerId, int pageNumber, int pageSize)
        {
            var query = new GetAllOrderByCustomerIdQuery(customerId, pageNumber, pageSize);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
    }
}
