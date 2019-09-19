using TFL.Sales.Domain.ProductRoot;

namespace TFL.Sales.Whole.Domain
{
    public class WholeLifeProduct : Product
    {
        public override ProductLineOfBusiness LineOfBusiness => ProductLineOfBusiness.Universal;
    }
}
