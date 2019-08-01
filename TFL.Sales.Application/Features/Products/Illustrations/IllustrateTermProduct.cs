using System;
using System.Linq;
using MediatR;
using TFL.Infrastructure.WebApi.Contracts;
using TFL.Sales.Domain.ProductRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;

namespace TFL.Sales.Application.Features.Products.Illustrations
{
    public class IllustrateTermProductRequest : IllustrateProductRequest, IRequest<IIlustrateTermProductResponse>{}

    public class IIlustrateTermProductResponse
    {
        public IIlustrateTermProductResponse(dynamic annualValues)
        {
            AnnualValues = annualValues;
        }

        public dynamic AnnualValues { get; }
    }

    internal class IllustrateTermProductHandler : RequestHandler<IllustrateTermProductRequest, IIlustrateTermProductResponse>
    {
        private readonly ITermIllustrationBuilder _illustrationBuilder;

        public IllustrateTermProductHandler(ITermIllustrationBuilder illustrationBuilder)
        {
            _illustrationBuilder = illustrationBuilder;
        }

        protected override IIlustrateTermProductResponse Handle(IllustrateTermProductRequest request)
        {
            //get details of the product
            //set basis of the illustration guaranteed, current, etc(will have a calculation per basis type)
            //adjust bounds = rabbit hole of hidden functionality, should be separated to be more explicit of what it is doing

            var options = new TermIllustrationOptions(15,"m",new TermLifeProduct());

            var illustration = _illustrationBuilder.GenerateIllustration(options);
                
            return new IIlustrateTermProductResponse(illustration[ProductIllustrationAnnualValuesType.CurrentValues].Select(x => new { x.Year, x.Age }).ToList());
        }
    }
}
