using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TFL.Sales.Application.Features.Products;
using TFL.Sales.Domain.ProductRoot.Ledger;
using TFL.Sales.Infrastructure.AzureTableQueries;
using TFL.Sales.Infrastructure.AzureTableQueries.Products;
using TFL.Sales.Term.Domain;
using TFL.Sales.Term.Domain.Ledger;

[assembly:InternalsVisibleTo("TFL.Sales.Term.Specs.Unit")]
namespace TFL.Sales.Term.Application
{
    public class CaluculateTermProductLedgerRequest : CalculateProductLedgerRequest, IRequest<CaluculateTermProductLedgerResponse>
    {
        public CaluculateTermProductLedgerRequest(string productPlanCode, int applicantAge, string applicantGender)
        {
            ProductPlanCode = productPlanCode;
            ApplicantAge = applicantAge;
            ApplicantGender = applicantGender;
        }
   
        public string ProductPlanCode { get; }

        public int ApplicantAge { get; }

        public string ApplicantGender { get; }
    }

    public class CaluculateTermProductLedgerResponse
    {
        public CaluculateTermProductLedgerResponse(dynamic annualValues)
        {
            AnnualValues = annualValues;
        }

        public dynamic AnnualValues { get; }
    }

    internal class CaluculateTermProductLedgerHandler : IRequestHandler<CaluculateTermProductLedgerRequest, CaluculateTermProductLedgerResponse>
    {
        private readonly ITermLedgerCalculator _ledgerCalculator;
        private readonly IFindTermProductAzureTableQuery _findTermProductQuery;

        public CaluculateTermProductLedgerHandler(ITermLedgerCalculator ledgerCalculator,IFindTermProductAzureTableQuery findTermProductQuery)
        {
            _ledgerCalculator = ledgerCalculator;
            _findTermProductQuery = findTermProductQuery;
        }

        public async Task<CaluculateTermProductLedgerResponse> Handle(CaluculateTermProductLedgerRequest request, CancellationToken token)
        {
            var product = GetProduct(request.ProductPlanCode);

            //set basis of  guaranteed, current, etc(will have a calculation per basis type)
            //adjust bounds = rabbit hole of hidden functionality, should be separated to be more explicit of what it is doing

            var options = new TermLedgerOptions(request.ApplicantAge,request.ApplicantGender, request.FaceAmount,product);

            var ledger = _ledgerCalculator.CalculateValues(options);
                
            return new CaluculateTermProductLedgerResponse(ledger[LedgerAnnualValuesType.CurrentValues].Select(x => new { x.Year, x.Age }).ToList());
        }

        TermLifeProduct GetProduct(string planCode)
        {
            var productTableEntity =
                _findTermProductQuery.Find(new RowKey(planCode), ProductPartitionKey.TermProductPartitionKey);

            return new TermLifeProduct
            {
                Description = productTableEntity.Description,Name = productTableEntity.Name,Id = new Guid(productTableEntity.RowKey),MaturityAge = productTableEntity.MaturityAge
            };
        }
    }
}
