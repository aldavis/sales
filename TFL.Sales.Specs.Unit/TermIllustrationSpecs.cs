using System.Linq;
using TFL.Sales.Domain.ProductRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;
using Xunit.Extensions;

namespace TFL.Sales.Specs.Unit
{
    public class illustration_should_have_annual_value_for_each_year_remaining_until_maturity : Specification
    {
        private ITermIllustrationBuilder _illustrationBuilder;

        private InsuredAge _insuredAgeForIllustration;
        private string _insuredGender;
        private TermLifeProduct _product;
        
        protected override void Observe()
        {
            _illustrationBuilder = new TermIllustrationBuilder();
            _insuredGender = "m";

            _product = new TermLifeProduct();
        }

        [Observation(DisplayName = "illustration for 41 year old should have 54 rows for annual value")]
        public void illustration_for_41_year_old_should_have_54_rows_for_annual_values()
        {
            _insuredAgeForIllustration = new InsuredAge(41);
            
            var illustration = _illustrationBuilder.GenerateIllustration(new ProductIllustrationOptions<TermLifeProduct>(_product,_insuredAgeForIllustration.Value,_insuredGender));
            illustration.Values.Count.ShouldEqual(1);
            illustration.Count(x => x.Key == ProductIllustrationAnnualValuesType.CurrentValues).ShouldEqual(1);
            illustration[ProductIllustrationAnnualValuesType.CurrentValues].Count.ShouldEqual(54);
        }
        
        [Observation(DisplayName = "illustration for 31 year old should have 64 rows for annual value")]
        public void illustration_for_31_year_old_should_have_54_rows_for_annual_values()
        {
            _insuredAgeForIllustration = new InsuredAge(31);
            
            var illustration = _illustrationBuilder.GenerateIllustration(new ProductIllustrationOptions<TermLifeProduct>(_product,_insuredAgeForIllustration.Value,_insuredGender));
            illustration.Values.Count.ShouldEqual(1);
            illustration.Count(x => x.Key == ProductIllustrationAnnualValuesType.CurrentValues).ShouldEqual(1);
            illustration[ProductIllustrationAnnualValuesType.CurrentValues].Count.ShouldEqual(64);
        }
    }
}
