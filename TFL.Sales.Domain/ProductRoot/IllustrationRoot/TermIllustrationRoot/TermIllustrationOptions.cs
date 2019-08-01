namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot
{
    public class TermIllustrationOptions : ProductIllustrationOptions<TermLifeProduct>
    {
        public TermIllustrationOptions(int insuredAgeForIllustration, string insuredGender, TermLifeProduct product) :
            base(product,insuredAgeForIllustration, insuredGender,ProductIllustrationAnnualValuesType.CurrentValues)
        {
        }
    }
}
