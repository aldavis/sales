using TFL.Sales.Domain.ProductRoot.Ledger;

namespace TFL.Sales.Universal.Domain.Ledger
{
    public class UniversalLedgerValue : LedgerValue<UniversalLifeProduct>
    {
        public decimal AnnualPremium { get; private set; }

        public decimal NetAnnualOutlay { get; private set; }

        public decimal TotalNetOutlay { get; private set; }

        public decimal AccountValue { get; private set; }

        public decimal SurrenderValue { get; private set; }

        public decimal NetDeathBenefitValue { get; private set; }

        public decimal NetLoan { get; private set; }

        public decimal NetWithdrawal { get; private set; }

        public static UniversalLedgerValue Create(
            LedgerYear year,
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
            return new UniversalLedgerValue
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