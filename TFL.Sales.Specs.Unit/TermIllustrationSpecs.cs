using System.Linq;
using TFL.Sales.Domain.ProductRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;
using Xunit.Extensions;

namespace TFL.Sales.Specs.Unit
{
    //TODO refactor so that either specification is more specific(1 verification per spec) or move executuion logic
    //into override and makes observations more focused
    public class illustration_should_run_until_endowment_age : Specification
    {
        private ITermIllustrationBuilder _illustrationBuilder;

        private InsuredAge _insuredAgeForIllustration;
        private string _insuredGender;
        private TermLifeProduct _product;
        
        protected override void Observe()
        {
            _illustrationBuilder = new TermIllustrationBuilder();
            _insuredGender = "m";
            _insuredAgeForIllustration = new InsuredAge(41);
            _product = new TermLifeProduct();
        }

        [Observation(DisplayName = "illustration for 41 year old should have 55 rows")]
        public void illustration_for_41_year_old_should_have_54_rows()
        {
            var illustration = _illustrationBuilder.GenerateIllustration(new ProductIllustrationOptions<TermLifeProduct>(_product,_insuredAgeForIllustration.Value,_insuredGender));
            illustration.Values.Count.ShouldEqual(1);
            illustration.Count(x => x.Key == ProductIllustrationAnnualValuesType.CurrentValues).ShouldEqual(1);
            illustration[ProductIllustrationAnnualValuesType.CurrentValues].Count.ShouldEqual(54);
        }
    }
}
