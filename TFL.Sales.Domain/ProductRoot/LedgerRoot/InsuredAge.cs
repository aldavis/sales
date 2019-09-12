using System;

namespace TFL.Sales.Domain.ProductRoot.LedgerRoot
{
    public class InsuredAge
    {
        public InsuredAge(int value)
        {
            if(value <= 0) throw new Exception("Insured age cannot be 0");
            Value = value;
        }
        public int Value { get; }
    }
}