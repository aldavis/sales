namespace TFL.Sales.Domain.ProductRoot.LedgerRoot.UniversalLedgerRoot
{
    public class UniversalLedgerOptions : LedgerOptions<UniversalLifeProduct>
    {
        public UniversalLedgerOptions(int insuredAge, string insuredGender, decimal policyFaceAmount,
            UniversalLifeProduct product) :
            base(product,
                insuredAge,
                insuredGender,
                policyFaceAmount,
                LedgerAnnualValuesType.CurrentValues,
                LedgerAnnualValuesType.ProjectedValues,
                LedgerAnnualValuesType.GuaranteedValues){}
    }
}