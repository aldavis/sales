using Microsoft.Azure.Cosmos.Table;

namespace TFL.Sales.Infrastructure.AzureTableQueries.Products
{
    public class ProductTableEntity : TableEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int MaturityAge { get; set; }

    }


}
