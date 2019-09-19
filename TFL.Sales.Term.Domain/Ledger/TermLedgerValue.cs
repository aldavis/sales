using TFL.Sales.Domain.ProductRoot.Ledger;

namespace TFL.Sales.Term.Domain.Ledger
{
    public class TermLedgerValue : LedgerValue<TermLifeProduct>
    {
        public decimal CurrentPremium { get; private set; }
        
        public decimal TotalCurrentPremium { get; private set; }
        
        public decimal MaximumGuaranteedPremium { get; private set; }
        
        public decimal TotalDeathBenefit { get; private set; }

        //can we do the calcuations at this level????
        public static TermLedgerValue Create(LedgerYear year, InsuredAge age ,decimal currentAnnualPremium, decimal totalAnnualPremium, decimal maxGuaranteedPremium, decimal totalDeathBenefit)
        {
            return new TermLedgerValue
            {
                Age = age.Value, 
                Year = year.Value,
                TotalCurrentPremium = totalAnnualPremium,
                CurrentPremium = currentAnnualPremium,
                MaximumGuaranteedPremium = maxGuaranteedPremium,
                TotalDeathBenefit = totalDeathBenefit
            };
        }
    }
}