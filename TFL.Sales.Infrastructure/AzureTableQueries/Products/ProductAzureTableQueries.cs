﻿using System.Linq;
using Microsoft.Azure.Cosmos.Table;

namespace TFL.Sales.Infrastructure.AzureTableQueries.Products
{
    public class ProductAzureTableQuery
    {
        protected const string TableName = "Products";
    }

    public interface IFindTermProductAzureTableQuery
    {
        ProductTableEntity Find(RowKey rowKey, PartitionKey partitionKey);

    }

    internal class FindTermProductAzureTableQuery : ProductAzureTableQuery, IFindTermProductAzureTableQuery
    {
        private readonly CloudTableClient _tableClient;

        public FindTermProductAzureTableQuery(CloudTableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public ProductTableEntity Find(RowKey rowKey, PartitionKey partitionKey)
        {
            var table = _tableClient.GetTableReference(TableName);

            var query = new TableQuery<ProductTableEntity>()
                .Where($"PartitionKey eq '{partitionKey.Value}' and RowKey eq '{rowKey.Value}'");

            var tableEntity = table.ExecuteQuery(query).FirstOrDefault();
            if (tableEntity != null) return tableEntity;

            throw new TableEntityNotFoundException($"Unable to find {partitionKey} product with plan code {rowKey}");
        }
    }
}