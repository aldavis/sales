namespace TFL.Sales.Domain.ProductRoot
{
    public class WholeLifeProduct : Product
    {
        public override ProductLineOfBusiness LineOfBusiness => ProductLineOfBusiness.Universal;
    }
}
