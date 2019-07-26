namespace TFL.Sales.Domain.ProductRoot
{
    public class UniversalLifeProduct : Product
    {
        public override ProductLineOfBusiness LineOfBusiness => ProductLineOfBusiness.Universal;
    }
}
