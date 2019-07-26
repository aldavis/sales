using System.Collections.Generic;

namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot
{
    public interface ITermProductIllustrationBuilder : IProductIllustrationBuilder<TermLifeProduct>{}

    public class TermProductIllustrationBuilder : ProductIllustrationBuilder<TermLifeProduct>, ITermProductIllustrationBuilder
    {
        protected override IList<ProductIllustrationAnnualValue<TermLifeProduct>> GetValues()
        {
            return new List<ProductIllustrationAnnualValue<TermLifeProduct>>
            {
                new ProductIllustrationAnnualValue<TermLifeProduct>{Age = 25, Year = 1987}
            };
        }
    }
}
