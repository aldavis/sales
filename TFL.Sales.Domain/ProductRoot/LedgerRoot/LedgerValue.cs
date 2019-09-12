namespace TFL.Sales.Domain.ProductRoot.LedgerRoot
{
    public class LedgerValue<T> where T: Product
    {
        public int Age { get; set; }

        public int Year { get; set; }
    }
}
