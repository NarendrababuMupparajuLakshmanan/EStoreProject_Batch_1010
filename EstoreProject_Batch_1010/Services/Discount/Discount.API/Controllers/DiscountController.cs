using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("CreateDiscount")]
        public IActionResult CreateDiscount(DiscountDTO discountDTO)
        {
            var command = new DiscountCreateCommand(discountDTO);

            var response = this._mediator.Send(command);

            return Ok(response);

        }

        [HttpGet]
        [Route("GetDiscountByProductID/{productID:guid}")]
        public IActionResult GetDiscountByProductID(Guid productID)
        {
            var query = new GetDiscountByProductID(productID);

            var result = this._mediator.Send(query).Result;

            return Ok(result);
        }

        [HttpGet]
        [Route("ListDiscount")]
        public IActionResult ListDiscount()
        {
            var query = new ListAllDiscountQuery();

            var result = this._mediator.Send(query).Result;

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteDiscount/{productID:guid}")]
        public IActionResult DeleteDiscuount(Guid productID)
        {
            var command = new DeleteDiscountByProductIDCommand(productID);

            var result = this._mediator.Send(command);

            return Ok(result);
        }
    }
}
