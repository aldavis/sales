namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot
{
    public class TermIllustrationAnnualValue : IllustrationValue<TermLifeProduct>
    {
        public decimal CurrentPremium { get; private set; }
        
        public decimal TotalCurrentPremium { get; private set; }
        
        public decimal MaximumGuaranteedPremium { get; private set; }
        
        public decimal TotalDeathBenefit { get; private set; }

        //can we do the calcuations at this level????
        public static TermIllustrationAnnualValue Create(PolicyIllustrationYear year, InsuredAge age ,decimal currentAnnualPremium, decimal totalAnnualPremium, decimal maxGuaranteedPremium, decimal totalDeathBenefit)
        {
            return new TermIllustrationAnnualValue
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