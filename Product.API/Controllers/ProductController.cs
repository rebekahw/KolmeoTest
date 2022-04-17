using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.ProductFeatures.Commands;
using Product.Application.ProductFeatures.Queries;

namespace Product.API.Controllers
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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Core.Models.Product>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Core.Models.Product>>> Get()
        {
            var r = await _mediator.Send(new GetAllProductsQuery());
            return Ok(r.ToList());
        }

        [HttpGet("{prodName}")]
        public async Task<List<Core.Models.Product>> GetProductByName(string prodName)
        {
            var r = await _mediator.Send(new GetProductByNameQuery { ProductName = prodName });
            return r.ToList();
        }
    }
}
