using Basket.Application.Commands;
using Basket.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("GetBasket")]
        public IActionResult GetBasket()
        {
            return Ok("Basket API is working!");
        }

        [HttpDelete]
        [Route("DeleteBasket/{userName}")]
        public IActionResult DeleteBasket(string userName)
        {
            var command = new DeleteBasketCommand(userName);

            var result = this._mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetBasketByUserName/{userName}")]
        public IActionResult GetBasketByUserName(string userName)
        {
            var query = new GetBasketByUsernameQuery(userName);

            var result = this._mediator.Send(query).Result;

            return Ok(result);
        }
    }
}
