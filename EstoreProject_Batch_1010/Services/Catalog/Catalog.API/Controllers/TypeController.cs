using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpGet]
        [Route("GetAllTypes")]
        public IActionResult GetAllTypes()
        {
            var query = new GetAllTypeQuery();

            var result = this._mediator.Send(query).Result;

            return Ok(result);
        }

        [HttpGet]
        [Route("GetTypeById/{Id:guid}")]
        public IActionResult GetTypeById(Guid Id)
        {
            var query = new GetTypeByIdQuery(Id);

            var result = this._mediator.Send(query).Result;

            return Ok(result);
        }
    }
}
