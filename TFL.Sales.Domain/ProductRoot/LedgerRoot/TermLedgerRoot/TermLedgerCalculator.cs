using System;
using System.Collections.Generic;

namespace TFL.Sales.Domain.ProductRoot.LedgerRoot.TermLedgerRoot
{
    public interface ITermLedgerCalculator : ILedgerCalculator<TermLifeProduct>{}

    public class TermLedgerCalculator : LedgerCalculator<TermLifeProduct>, ITermLedgerCalculator
    {
        protected override Dictionary<LedgerAnnualValuesType,IList<LedgerValue<TermLifeProduct>>> BuildLedgerValues()
        {
            var annualValues = new List<LedgerValue<TermLifeProduct>>();

            var applicantAge = Math.Max(LedgerOptions.Product.MinimumIssueAge, LedgerOptions.InsuredAgeForLedger);
            var policyFaceAmount = Math.Max(LedgerOptions.Product.MinimumFaceAmount, LedgerOptions.PolicyFaceAmount);

            //set the riskclass somewhere
            //adjust the bounds/bands if needed

            var counter = 0;
            for (var i = applicantAge; i < LedgerOptions.Product.MaturityAge; i++)
            {
                var illustrationYear = new LedgerYear(DateTime.Now.AddYears(counter).Year);

                var illustrationAnnualValue =
                    TermLedgerValue.Create(illustrationYear, new InsuredAge(i), 100, 100, 100, policyFaceAmount);

                annualValues.Add(illustrationAnnualValue);

                counter++;

            }

            return new Dictionary<LedgerAnnualValuesType, IList<LedgerValue<TermLifeProduct>>>
            {
                {LedgerAnnualValuesType.CurrentValues,annualValues}
            };
        }
    }
}
