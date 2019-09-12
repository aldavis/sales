using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TFL.Sales.Domain.ProductRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;
using Xbehave;

namespace TFL.Sales.Specs.Unit
{
    public class TermIllustrationSpecs
    {
        private readonly string _insuredGender;
        private readonly TermLifeProduct _product;
        private readonly ITermIllustrationBuilder _illustrationBuilder;

        private InsuredAge _insuredAgeForIllustration;

        private Dictionary<ProductIllustrationAnnualValuesType, IList<IllustrationValue<TermLifeProduct>>> _illustration;

        public TermIllustrationSpecs()
        {
            _illustrationBuilder = new TermIllustrationBuilder();
            _insuredGender = "m";

            _product = new TermLifeProduct();
        }

        [Scenario]
        public void illustration_for_41_year_old_should_have_54_rows_for_annual_values()
        {
            "Given: insured at age 41"
                .x(() => _insuredAgeForIllustration = new InsuredAge(41));

            "When: illustration is generated"
                .x(() => _illustration = _illustrationBuilder.GenerateIllustration(
                    new ProductIllustrationOptions<TermLifeProduct>(_product, _insuredAgeForIllustration.Value,
                        _insuredGender)));

            "Then: response should contain 1 illustration"
                .x(() => _illustration.Values.Count.ShouldBe(1));

            "And: illustration should contain current annual values"
                .x(() => _illustration.Count(x => x.Key == ProductIllustrationAnnualValuesType.CurrentValues)
                    .ShouldBe(1));

            "And: current annual values should contain 54 rows"
                .x(() => _illustration[ProductIllustrationAnnualValuesType.CurrentValues].Count.ShouldBe(54));
        }

        [Scenario]
        public void illustration_for_31_year_old_should_have_64_rows_for_annual_values()
        {
            "Given: insured at age 31"
                .x(() => _insuredAgeForIllustration = new InsuredAge(31));

            "When: illustration is generated"
                .x(() => _illustration = _illustrationBuilder.GenerateIllustration(
                    new ProductIllustrationOptions<TermLifeProduct>(_product, _insuredAgeForIllustration.Value,
                        _insuredGender)));

            "Then: response should contain 1 illustration"
                .x(() => _illustration.Values.Count.ShouldBe(1));

            "And: illustration should contain current annual values"
                .x(() => _illustration.Count(x => x.Key == ProductIllustrationAnnualValuesType.CurrentValues)
                    .ShouldBe(1));

            "And: current annual values should contain 64 rows"
                .x(() => _illustration[ProductIllustrationAnnualValuesType.CurrentValues].Count.ShouldBe(64));
        }
    }
}