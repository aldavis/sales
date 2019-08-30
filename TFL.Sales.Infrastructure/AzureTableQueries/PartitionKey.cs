using System;

namespace TFL.Sales.Infrastructure.AzureTableQueries
{
    public class PartitionKey
    {
        public PartitionKey(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                //TODO add custom exception
                throw new Exception("partition key cannot be empty");
            }

            Value = value;
        }

        public string Value { get; }
    }
}