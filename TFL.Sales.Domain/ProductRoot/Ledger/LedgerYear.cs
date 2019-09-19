using System;

namespace TFL.Sales.Domain.ProductRoot.Ledger
{
    public class LedgerYear
    {
        public LedgerYear(int value)
        {
            if(value <= 0) throw new Exception("Ledger cannot have year 0");
            
            Value = value;
        }
        
        public int Value { get; }
    }
}