using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Core.DTOs.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductByBrandId/{Id:guid}")]
        public IActionResult GetProductByBrandId(Guid Id)
        {
            var query = new GetProductByBrandIdQuery(Id);
            var products = _mediator.Send(query).Result;
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductByTypeId/{Id:guid}")]
        public IActionResult GetProductByTypeId(Guid Id)
        {
            var query = new GetProductByTypeIdQuery(Id);
            var products = _mediator.Send(query).Result;
            return Ok(products);
        }

        [HttpPost]
        [Route("CreateProduct")]
        [Consumes("multipart/form-data")]
        public IActionResult CreateProduct([FromForm] CreateProductDTO createProductDTO)
        {
            var command = new CreateProductCommand(createProductDTO);
            var productId = _mediator.Send(command).Result;
            return Ok(productId);
        }

        [HttpDelete]
        [Route("DeleteProduct/{Id:guid}")]
        public IActionResult DeleteProduct(Guid Id)
        {
            var command = new DeleteProductCommand(Id);
            var result = this._mediator.Send(command);
            return Ok(result);
        }
    }
}
