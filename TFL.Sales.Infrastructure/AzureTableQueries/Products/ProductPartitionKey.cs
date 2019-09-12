namespace TFL.Sales.Infrastructure.AzureTableQueries.Products
{
    public class ProductPartitionKey
    {
        private static PartitionKey _termProductPartitionKey;

        public static PartitionKey TermProductPartitionKey
        {
            get
            {
                if (_termProductPartitionKey == null)
                {
                    _termProductPartitionKey = new PartitionKey("Term");
                }

                return _termProductPartitionKey;
            }
        }
    }
}
