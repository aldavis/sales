using System;
using System.Linq;
using MediatR;
using TFL.Infrastructure.WebApi.Contracts;
using TFL.Sales.Domain.ProductRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.UniversalIllustrationRoot;

namespace TFL.Sales.Application.Features.Products.Illustrations
{
    public class IllustrateUniversalProductRequest : IllustrateProductRequest, IRequest<IIlustrateUniversalProductResponse>{}

    public class IIlustrateUniversalProductResponse
    {
        public IIlustrateUniversalProductResponse(dynamic projectedValues, dynamic currentValues, dynamic guaranteedValues)
        {
            ProjectedValues = projectedValues;
            CurrentValues = currentValues;
            GuaranteedValues = guaranteedValues;
        }

        public dynamic ProjectedValues { get; }
        public dynamic CurrentValues { get; }
        public dynamic GuaranteedValues { get; }
    }

    internal class IllustrateUniversalProductHandler : RequestHandler<IllustrateUniversalProductRequest, IIlustrateUniversalProductResponse>
    {
        private readonly IUniversalIllustrationBuilder _illustrationBuilder;

        public IllustrateUniversalProductHandler(IUniversalIllustrationBuilder illustrationBuilder)
        {
            _illustrationBuilder = illustrationBuilder;
        }

        protected override IIlustrateUniversalProductResponse Handle(IllustrateUniversalProductRequest request)
        {
            //get details of the product
            var product = new UniversalLifeProduct();
            
            var options = new UniversalIllustrationOptions(15,"m",product);

            var illustration = _illustrationBuilder.GenerateIllustration(options);

            var currentValues = illustration[ProductIllustrationAnnualValuesType.CurrentValues].Select(x => new {x.Year,x.Age});
            var projectedValues = illustration[ProductIllustrationAnnualValuesType.ProjectedValues].Select(x => new {x.Year,x.Age});
            var guaranteedValues = illustration[ProductIllustrationAnnualValuesType.GuaranteedValues].Select(x => new {x.Year,x.Age});
            
            return new IIlustrateUniversalProductResponse(projectedValues,currentValues,guaranteedValues);
        }
    }
}
