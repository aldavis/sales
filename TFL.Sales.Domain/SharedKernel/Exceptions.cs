using System;

namespace TFL.Sales.Domain.SharedKernel
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message){}
    }
}
