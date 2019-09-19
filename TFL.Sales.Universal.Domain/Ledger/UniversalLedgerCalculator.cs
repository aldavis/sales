using System;
using System.Collections.Generic;
using TFL.Sales.Domain.ProductRoot.Ledger;

namespace TFL.Sales.Universal.Domain.Ledger
{
    public interface IUniversalLedgerCalculator : ILedgerCalculator<UniversalLifeProduct>
    {
    }

    public class UniversalLedgerCalculator : LedgerCalculator<UniversalLifeProduct>,IUniversalLedgerCalculator
    {
        protected override Dictionary<LedgerAnnualValuesType, IList<LedgerValue<UniversalLifeProduct>>>BuildLedgerValues()
        {
            var illustrationAnnualValues = new List<LedgerValue<UniversalLifeProduct>>();

            var counter = 0;
            for (var i = LedgerOptions.InsuredAgeForLedger;
                i < LedgerOptions.Product.MaturityAge;
                i++)
            {
                var illustrationYear = new LedgerYear(DateTime.Now.AddYears(counter).Year);
                var insuredAge = new InsuredAge(i);
                var annualPremium = 100;
                var netOutlay = 100;
                var totalNetOutlay = 100;
                var accountValue = 100;
                var surrenderValue = 100;
                var netDeathBenefit = 100;
                var netLoan = 100;
                var netWithdrawal = 100;

                var annualValue = UniversalLedgerValue
                    .Create(illustrationYear,
                        insuredAge,
                        annualPremium,
                        netOutlay,
                        totalNetOutlay,
                        accountValue,
                        surrenderValue,
                        netDeathBenefit,
                        netLoan,
                        netWithdrawal);

                illustrationAnnualValues.Add(annualValue);
                
                counter++;
            }

            return new Dictionary<LedgerAnnualValuesType,
                IList<LedgerValue<UniversalLifeProduct>>>
            {
                {LedgerAnnualValuesType.CurrentValues, illustrationAnnualValues}
            };
        }
    }
}