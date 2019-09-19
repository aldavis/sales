using System.Linq;
using MediatR;
using TFL.Sales.Application.Features.Products;
using TFL.Sales.Domain.ProductRoot.Ledger;
using TFL.Sales.Universal.Domain;
using TFL.Sales.Universal.Domain.Ledger;

namespace TFL.Sales.Universal.Application
{
    public class CalculateUniversalProductLedgerRequest : CalculateProductLedgerRequest, IRequest<CalculateUniversalProductLedgerResponse> {}

    public class CalculateUniversalProductLedgerResponse
    {
        public CalculateUniversalProductLedgerResponse(dynamic projectedValues, dynamic currentValues, dynamic guaranteedValues)
        {
            ProjectedValues = projectedValues;
            CurrentValues = currentValues;
            GuaranteedValues = guaranteedValues;
        }

        public dynamic ProjectedValues { get; }
        public dynamic CurrentValues { get; }
        public dynamic GuaranteedValues { get; }
    }

    internal class CalculateUniversalProductLedgerHandler : RequestHandler<CalculateUniversalProductLedgerRequest, CalculateUniversalProductLedgerResponse>
    {
        private readonly IUniversalLedgerCalculator _ledgerCalculator;

        public CalculateUniversalProductLedgerHandler(IUniversalLedgerCalculator ledgerCalculator)
        {
            _ledgerCalculator = ledgerCalculator;
        }

        protected override CalculateUniversalProductLedgerResponse Handle(CalculateUniversalProductLedgerRequest request)
        {
            //get details of the product
            var product = new UniversalLifeProduct();
            
            var options = new UniversalLedgerOptions(15,"m", request.FaceAmount,product);

            var ledger = _ledgerCalculator.CalculateValues(options);

            var currentValues = ledger[LedgerAnnualValuesType.CurrentValues].Select(x => new {x.Year,x.Age});
            var projectedValues = ledger[LedgerAnnualValuesType.ProjectedValues].Select(x => new {x.Year,x.Age});
            var guaranteedValues = ledger[LedgerAnnualValuesType.GuaranteedValues].Select(x => new {x.Year,x.Age});
            
            return new CalculateUniversalProductLedgerResponse(projectedValues,currentValues,guaranteedValues);
        }
    }
}
