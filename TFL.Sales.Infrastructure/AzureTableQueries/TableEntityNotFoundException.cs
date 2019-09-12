using System;

namespace TFL.Sales.Infrastructure.AzureTableQueries
{
    public class TableEntityNotFoundException : Exception
    {
        public TableEntityNotFoundException(string message) : base(message){}
    }
}
