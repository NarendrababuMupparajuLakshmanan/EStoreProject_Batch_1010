using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Core.DTOs.Brands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllBrands")]
        public IActionResult GetAllBrands()
        {
            var query = new GetAllBrandQuery();
            var response = this._mediator.Send(query).Result;

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateBrand")]
        public IActionResult CreateBrand(CreateBrandDTO createBrand)
        {
            var command = new CreateBrandCommand(createBrand.Name);
            var result = this._mediator.Send(command).Result;

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteBrand/{Id:guid}")]
        public IActionResult DeleteBrand(Guid Id)
        {
            var command = new DeleteBrandCommand(Id);

            var result = this._mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateBrand")]
        public IActionResult UpdateBrand(UpdateBrandDTO updateBrandDTO)
        {
            var command = new UpdateBrandCommand(updateBrandDTO);
            var result = this._mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("GetBrandById/{Id:guid}")]
        public IActionResult GetBrandById(Guid Id)
        {
            var query = new GetBrandByIdQuery(Id);
            var response = this._mediator.Send(query).Result;

            return Ok(response);
        }

    }
}
