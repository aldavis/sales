using System.Collections.Generic;

namespace TFL.Sales.Domain.ProductRoot.LedgerRoot
{
    public class LedgerOptions<T> where T : Product 
    {
        public LedgerOptions( T product,int insuredAgeForLedger, string insuredGender, decimal policyFaceAmount,params LedgerAnnualValuesType[] illustrationValuesTypes)
        {
            Product = product;
            InsuredAgeForLedger = insuredAgeForLedger;
            InsuredGender = insuredGender;
            IllustrationValuesTypes = illustrationValuesTypes;
            PolicyFaceAmount = policyFaceAmount;

        }
        
        public T Product { get; }
        
        public int InsuredAgeForLedger { get; }
        
        public string InsuredGender { get; }

        public decimal PolicyFaceAmount { get; }
        
        public IList<LedgerAnnualValuesType> IllustrationValuesTypes { get; }
    }
}
