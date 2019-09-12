using System;

namespace TFL.Sales.Infrastructure.AzureTableQueries
{
    public class RowKey
    {
        public RowKey(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                //TODO add custom exception
                throw new Exception("row key cannot be empty");
            }

            Value = value;
        }

        public string Value { get; }
    }
}