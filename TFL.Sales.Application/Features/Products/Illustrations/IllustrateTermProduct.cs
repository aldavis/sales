using System;
using System.Linq;
using MediatR;
using TFL.Infrastructure.WebApi.Contracts;
using TFL.Sales.Domain.ProductRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;

namespace TFL.Sales.Application.Features.Products.Illustrations
{
    public class IllustrateTermProductRequest : ApiRequest, IRequest<IIllustrateTermProductResponse>
    {
        public Guid ProductId { get; set; }

        public ProductLineOfBusiness ProductLineOfBusiness { get; set; }

        public decimal BenefitAmount { get; set; }

        public int InsuredAge { get; set; }

        public string InsuredGender { get; set; }
    }

    public class IIllustrateTermProductResponse
    {
        public IIllustrateTermProductResponse(dynamic annualValues)
        {
            AnnualValues = annualValues;
        }

        public dynamic AnnualValues { get; }
    }

    internal class IllustrateProductHandler : RequestHandler<IllustrateTermProductRequest, IIllustrateTermProductResponse>
    {
        private readonly ITermProductIllustrationBuilder _illustrationBuilder;

        public IllustrateProductHandler(ITermProductIllustrationBuilder illustrationBuilder)
        {
            _illustrationBuilder = illustrationBuilder;
        }

        protected override IIllustrateTermProductResponse Handle(IllustrateTermProductRequest request)
        {
            //get details of the product
            //set basis of the illustration guaranteed, current, etc(will have a calculation per basis type)
            //adjust bounds = rabbit hole of hidden functionality, should be separated to be more explicit of what it is doing

            var options = new TermProductIllustrationOptions();

            var illustration = _illustrationBuilder.GenerateIllustration(options);
                
            return new IIllustrateTermProductResponse(illustration.Select(x => new { x.Year, x.Age }).ToList());
        }
    }
}
