using Application.CustomerCRUD.Commands.Add;
using Application.ProductCRUD.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// CreateProduct
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/add")]
        public async Task<IActionResult> CreateProduct(AddProductCommand command)
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }
    }


}
