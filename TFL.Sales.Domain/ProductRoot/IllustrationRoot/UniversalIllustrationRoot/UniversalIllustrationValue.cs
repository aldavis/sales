namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot.UniversalIllustrationRoot
{
    public class UniversalIllustrationAnnualValue : IllustrationValue<UniversalLifeProduct>
    {
        public decimal AnnualPremium { get; private set; }

        public decimal NetAnnualOutlay { get; private set; }

        public decimal TotalNetOutlay { get; private set; }

        public decimal AccountValue { get; private set; }

        public decimal SurrenderValue { get; private set; }

        public decimal NetDeathBenefitValue { get; private set; }

        public decimal NetLoan { get; private set; }

        public decimal NetWithdrawal { get; private set; }

        public static UniversalIllustrationAnnualValue Create(
            PolicyIllustrationYear year,
            InsuredAge age,
            decimal annualPremium,
            decimal netAnnualOutlay,
            decimal totalNetOutlay,
            decimal accountValue,
            decimal surrenderValue,
            decimal netDeathBenefit,
            decimal netLoan,
            decimal netWithdrawal)
        {
            return new UniversalIllustrationAnnualValue
            {
                Age = age.Value,
                Year = year.Value,
                AnnualPremium = annualPremium,
                NetAnnualOutlay= netAnnualOutlay,
                TotalNetOutlay = totalNetOutlay,
                AccountValue = accountValue,
                SurrenderValue = surrenderValue,
                NetDeathBenefitValue = netDeathBenefit,
                NetLoan = netLoan,
                NetWithdrawal = netWithdrawal
            };
        }
    }
}