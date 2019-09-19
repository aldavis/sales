using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TFL.Sales.Domain.ProductRoot.Ledger;
using TFL.Sales.Term.Domain;
using TFL.Sales.Term.Domain.Ledger;
using Xbehave;

namespace TFL.Sales.Term.Specs.Unit.LedgerSpecs
{
    public class TermLedgerCalculatorSpecs
    {
        private readonly string _insuredGender;
        private readonly TermLifeProduct _product;
        private readonly ITermLedgerCalculator _ledgerCalculator;
        private readonly decimal _policyFaceAmount;

        private InsuredAge _insuredAgeForIllustration;

        private Dictionary<LedgerAnnualValuesType, IList<LedgerValue<TermLifeProduct>>> _ledger;

        public TermLedgerCalculatorSpecs()
        {
            _ledgerCalculator = new TermLedgerCalculator();
            _insuredGender = "m";
            _policyFaceAmount = 10000;

            _product = new TermLifeProduct
            {
                MaturityAge = 95
            };
        }

        [Scenario]
        public void ledger_for_41_year_old_should_have_54_rows_for_annual_values()
        {
            "Given: insured at age 41"
                .x(() => _insuredAgeForIllustration = new InsuredAge(41));

            "When: ledger is generated"
                .x(() => _ledger = _ledgerCalculator.CalculateValues(
                    new LedgerOptions<TermLifeProduct>(_product, _insuredAgeForIllustration.Value,
                        _insuredGender,_policyFaceAmount)));

            "Then: response should contain 1 set of values"
                .x(() => _ledger.Values.Count.ShouldBe(1));

            "And: ledger should contain current annual values"
                .x(() => _ledger.Count(x => x.Key == LedgerAnnualValuesType.CurrentValues)
                    .ShouldBe(1));

            "And: current annual values should contain 54 rows"
                .x(() => _ledger[LedgerAnnualValuesType.CurrentValues].Count.ShouldBe(54));
        }

        [Scenario]
        public void ledger_for_31_year_old_should_have_64_rows_for_annual_values()
        {
            "Given: insured at age 31"
                .x(() => _insuredAgeForIllustration = new InsuredAge(31));

            "When: ledger is generated"
                .x(() => _ledger = _ledgerCalculator.CalculateValues(
                    new LedgerOptions<TermLifeProduct>(_product, _insuredAgeForIllustration.Value,
                        _insuredGender, _policyFaceAmount)));

            "Then: response should contain 1 set of values"
                .x(() => _ledger.Values.Count.ShouldBe(1));

            "And: ledger should contain current annual values"
                .x(() => _ledger.Count(x => x.Key == LedgerAnnualValuesType.CurrentValues)
                    .ShouldBe(1));

            "And: current annual values should contain 64 rows"
                .x(() => _ledger[LedgerAnnualValuesType.CurrentValues].Count.ShouldBe(64));
        }
    }
}