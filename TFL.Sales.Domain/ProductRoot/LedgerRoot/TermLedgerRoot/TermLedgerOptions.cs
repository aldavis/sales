namespace TFL.Sales.Domain.ProductRoot.LedgerRoot.TermLedgerRoot
{
    public class TermLedgerOptions : LedgerOptions<TermLifeProduct>
    {
        public TermLedgerOptions(int insuredAgeForIllustration, string insuredGender, decimal policyFaceAmount,TermLifeProduct product) :
            base(product,insuredAgeForIllustration, insuredGender, policyFaceAmount, LedgerAnnualValuesType.CurrentValues)
        {
        }
    }
}
