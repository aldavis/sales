using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TFL.Infrastructure.WebApi.Contracts;

namespace TFL.Sales.Application.Features.Products
{
    public class GetActiveProductsRequest : ApiRequest, IRequest<GetActiveProductsResponse>
    {
        public string Test { get; set; }
    }

    public class GetActiveProductsResponse
    {
        public GetActiveProductsResponse(IList<ActiveProductListItem> products)
        {
            Products = products;
        }

        public IList<ActiveProductListItem> Products { get; }
    }

    public class ActiveProductListItem
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    internal class GetActiveProductsHandler : IRequestHandler<GetActiveProductsRequest, GetActiveProductsResponse>
	{
		public async Task<GetActiveProductsResponse> Handle(GetActiveProductsRequest request, CancellationToken cancellationToken)
		{
			return new GetActiveProductsResponse(new List<ActiveProductListItem>{new ActiveProductListItem{Description = "Test Description", Name = "TestName"}});
		}
	}
}
