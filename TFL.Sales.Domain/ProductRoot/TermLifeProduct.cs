namespace TFL.Sales.Domain.ProductRoot
{
    public class TermLifeProduct : Product
    {
        public override ProductLineOfBusiness LineOfBusiness => ProductLineOfBusiness.Term;
    }
}
