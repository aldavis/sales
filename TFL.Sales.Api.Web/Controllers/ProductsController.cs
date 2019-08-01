using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFL.Infrastructure.WebApi;
using TFL.Sales.Application.Features.Products;
using TFL.Sales.Application.Features.Products.Illustrations;

namespace TFL.Sales.Api.Web.Controllers
{
	[Route("api/[controller]")]
	public class ProductsController : BaseController
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("active", Name = "get active products")]
		[ProducesResponseType(typeof(GetActiveProductsResponse), 200)]
		public async Task<IActionResult> GetActiveProducts(CancellationToken token)
		{
			var result = await _mediator.Send(new GetActiveProductsRequest{Test = "something"},token);

			return Ok(result);
		}

		//TODO put more thought toward the illustration of products being its own service since it is looking to be pretty involved
        [HttpGet("term/illustrate", Name = "illustrate term product")]
        [ProducesResponseType(typeof(IIlustrateTermProductResponse), 200)]
        public async Task<IActionResult> IllustrateTermProduct(IllustrateTermProductRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(request, token);

            return Ok(result);
        }
        
        [HttpGet("universal/illustrate", Name = "illustrate universal product")]
        [ProducesResponseType(typeof(IIlustrateUniversalProductResponse), 200)]
        public async Task<IActionResult> IllustrateUniversalProduct(IllustrateUniversalProductRequest request, CancellationToken token)
        {
	        var result = await _mediator.Send(request, token);

	        return Ok(result);
        }

    }
}
