using TFL.Sales.Domain.ProductRoot;
using TFL.Sales.Domain.SharedKernel;

namespace TFL.Sales.Term.Domain
{
    public class TermLifeProduct : Product
    {
        public override ProductLineOfBusiness LineOfBusiness => ProductLineOfBusiness.Term;      
        
        public decimal MinimumFaceAmount { get; private set; }

        public void SetMinimumFaceAmount(decimal amount)
        {
            if (amount <= 0) throw new BusinessRuleException("minimum face amount of product must be greater than 0");

            MinimumFaceAmount = amount;

        }
    }
}
