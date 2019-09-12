namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot.UniversalIllustrationRoot
{
    public class UniversalIllustrationOptions : ProductIllustrationOptions<UniversalLifeProduct>
    {
        public UniversalIllustrationOptions(int insuredAgeForIllustration, string insuredGender,
            UniversalLifeProduct product) :
            base(product,
                insuredAgeForIllustration,
                insuredGender,
                ProductIllustrationAnnualValuesType.CurrentValues,
                ProductIllustrationAnnualValuesType.ProjectedValues,
                ProductIllustrationAnnualValuesType.GuaranteedValues){}
    }
}