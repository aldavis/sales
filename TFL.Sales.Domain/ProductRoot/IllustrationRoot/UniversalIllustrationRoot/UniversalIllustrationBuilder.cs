using System;
using System.Collections.Generic;

namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot.UniversalIllustrationRoot
{
    public interface IUniversalIllustrationBuilder : IIllustrationBuilder<UniversalLifeProduct>
    {
    }

    public class UniversalIllustrationBuilder : IllustrationBuilder<UniversalLifeProduct>,
        IUniversalIllustrationBuilder
    {
        protected override
            Dictionary<ProductIllustrationAnnualValuesType, IList<IllustrationValue<UniversalLifeProduct>>>
            BuildProductIllustration()
        {
            var illustrationAnnualValues = new List<IllustrationValue<UniversalLifeProduct>>();

            var counter = 0;
            for (var i = IllustrationOptions.InsuredAgeForIllustration;
                i < IllustrationOptions.Product.MaturityAge;
                i++)
            {
                var illustrationYear = new PolicyIllustrationYear(DateTime.Now.AddYears(counter).Year);
                var insuredAge = new InsuredAge(i);
                var annualPremium = 100;
                var netOutlay = 100;
                var totalNetOutlay = 100;
                var accountValue = 100;
                var surrenderValue = 100;
                var netDeathBenefit = 100;
                var netLoan = 100;
                var netWithdrawal = 100;

                var annualValue = UniversalIllustrationAnnualValue
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

            return new Dictionary<ProductIllustrationAnnualValuesType,
                IList<IllustrationValue<UniversalLifeProduct>>>
            {
                {ProductIllustrationAnnualValuesType.CurrentValues, illustrationAnnualValues}
            };
        }
    }
}