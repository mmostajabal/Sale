using Application.CustomerCRUD.Commands.Add;
using Application.CustomerCRUD.Commands.Delete;
using Application.CustomerCRUD.Commands.Update;
using Application.CustomerCRUD.Queries;
using Application.CustomerCRUD.Queries.Get;
using Application.CustomerCRUD.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// GetCustomerOrders
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            var query = new GetCustomerQuery(customerId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
        /// <summary>
        /// GetAllCustomer
        /// </summary>
        /// <returns></returns>
        [HttpGet("/all")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var query = new GetAllQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        /// <summary>
        /// CreateCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/addcustomer")]
        public async Task<IActionResult> CreateCustomer(AddCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }

        [HttpPost("/update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("/delete")]
        public async Task<IActionResult> deleteCustomer(DeleteCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
