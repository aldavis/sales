using System.Threading;
using Moq;
using TFL.Sales.Application.Features.Products.Ledgers;
using TFL.Sales.Domain.ProductRoot.LedgerRoot.TermLedgerRoot;
using TFL.Sales.Infrastructure.AzureTableQueries;
using TFL.Sales.Infrastructure.AzureTableQueries.Products;
using Xbehave;
using Xunit;

namespace TFL.Sales.Specs.Unit.ProductSpecs.IllustrationSpecs.TermProductIllustrationSpecs
{
    public class CalculateTermProductLedgerHandlerSpecs
    {
        private CaluculateTermProductLedgerHandler _handler;
        private Mock<IFindTermProductAzureTableQuery> _mockFindTermProductQuery;

        public CalculateTermProductLedgerHandlerSpecs()
        {
            _mockFindTermProductQuery = new Mock<IFindTermProductAzureTableQuery>();
        }

        [Scenario]
        public void product_not_found_throws_exception()
        {
            _mockFindTermProductQuery.Setup(x => 
                x.Find(It.IsAny<RowKey>(), It.IsAny<PartitionKey>()))
                .Throws(new TableEntityNotFoundException("foo"));

            var request = new CaluculateTermProductLedgerRequest("001",35,"m");

            "Given::".x(() =>
                _handler = new CaluculateTermProductLedgerHandler(new TermLedgerCalculator(),_mockFindTermProductQuery.Object));

            "Then:".x(() => Assert.ThrowsAsync<TableEntityNotFoundException>(() => _handler.Handle(request,CancellationToken.None)));
        }
    }
}
