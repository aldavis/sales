using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TFL.Infrastructure.WebApi;
using TFL.Sales.Application.Features.Products;
using TFL.Sales.Term.Application;
using TFL.Sales.Universal.Application;

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

        [HttpGet("term/ledger/values", Name = "calculate ledger for term product")]
        [ProducesResponseType(typeof(CaluculateTermProductLedgerResponse), 200)]
        public async Task<IActionResult> CalculateTermProductLedger(CaluculateTermProductLedgerRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(request, token);

            return Ok(result);
        }
        
        [HttpGet("universal/ledger/values", Name = "calculate ledger for universal product")]
        [ProducesResponseType(typeof(CalculateUniversalProductLedgerRequest), 200)]
        public async Task<IActionResult> CalculateUniversalProductLedger(CalculateUniversalProductLedgerRequest request, CancellationToken token)
        {
	        var result = await _mediator.Send(request, token);

	        return Ok(result);
        }

    }
}
