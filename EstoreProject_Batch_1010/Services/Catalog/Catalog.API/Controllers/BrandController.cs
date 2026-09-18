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
             
    }
}
