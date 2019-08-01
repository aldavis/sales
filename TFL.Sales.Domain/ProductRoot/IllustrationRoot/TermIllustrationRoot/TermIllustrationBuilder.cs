using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot
{
    public interface ITermIllustrationBuilder : IIllustrationBuilder<TermLifeProduct>{}

    public class TermIllustrationBuilder : IllustrationBuilder<TermLifeProduct>, ITermIllustrationBuilder
    {
        protected override Dictionary<ProductIllustrationAnnualValuesType,IList<IllustrationValue<TermLifeProduct>>> BuildProductIllustration()
        {
            var illustrationAnnualValues = new List<IllustrationValue<TermLifeProduct>>();

            var counter = 0;
            for (var i = IllustrationOptions.InsuredAgeForIllustration; i < IllustrationOptions.Product.MaturityAge; i++)
            {
                var illustrationYear = new PolicyIllustrationYear(DateTime.Now.AddYears(counter).Year);
                var insuredAge = new InsuredAge(i);
                illustrationAnnualValues.Add(TermIllustrationAnnualValue.Create(illustrationYear, insuredAge,100,100,100,100));
                counter++;
            }

            return new Dictionary<ProductIllustrationAnnualValuesType, IList<IllustrationValue<TermLifeProduct>>>
            {
                {ProductIllustrationAnnualValuesType.CurrentValues,illustrationAnnualValues}
            };
        }
    }
}
