using TFL.Sales.Domain.ProductRoot.Ledger;

namespace TFL.Sales.Term.Domain.Ledger
{
    public class TermLedgerOptions : LedgerOptions<TermLifeProduct>
    {
        public TermLedgerOptions(int insuredAgeForIllustration, string insuredGender, decimal policyFaceAmount,TermLifeProduct product) :
            base(product,insuredAgeForIllustration, insuredGender, policyFaceAmount, LedgerAnnualValuesType.CurrentValues)
        {
        }
    }
}
