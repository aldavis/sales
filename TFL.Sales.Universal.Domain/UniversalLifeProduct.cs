using TFL.Sales.Domain.ProductRoot;

namespace TFL.Sales.Universal.Domain
{
    public class UniversalLifeProduct : Product
    {
        public override ProductLineOfBusiness LineOfBusiness => ProductLineOfBusiness.Universal;

        public int MaturityAge => 100;
    }
}
