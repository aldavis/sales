using System;
using FluentValidation;
using TFL.Infrastructure.WebApi.Contracts;

namespace TFL.Sales.Application.Features.Products
{
    public class ActivateProductRequest : ApiRequest
    {
        public ActivateProductRequest(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; }
    }

    public class ActivateProductsValidator : AbstractValidator<ActivateProductRequest>
	{
		public ActivateProductsValidator()
		{
			RuleFor(x => x.ProductId)
				.NotEmpty()
				.NotEqual(Guid.Empty)
				.WithMessage("ProductId supplied was invalid");
		}
	}
}
