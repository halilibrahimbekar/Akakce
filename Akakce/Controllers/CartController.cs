using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Commands.Request;
using Service.Services.Commands.Response;

namespace Akakce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/AddtoCart
        [HttpPost]
        public async Task<ActionResult<AddToCartResponse>> AddToCart(AddToCartRequest cart)
        {
            var result = await _mediator.Send(cart);

            return Ok(result);
        }
    }
}
