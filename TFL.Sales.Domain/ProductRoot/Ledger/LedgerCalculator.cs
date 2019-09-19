using System.Collections.Generic;

namespace TFL.Sales.Domain.ProductRoot.Ledger
{
    public interface ILedgerCalculator<T> where T: Product
    {
        Dictionary<LedgerAnnualValuesType,IList<LedgerValue<T>>> CalculateValues(LedgerOptions<T> options);
    }

    public abstract class LedgerCalculator<T> : ILedgerCalculator<T> where T : Product
    {
        protected LedgerOptions<T> LedgerOptions;

        public Dictionary<LedgerAnnualValuesType,IList<LedgerValue<T>>> CalculateValues(LedgerOptions<T> options)
        {
            LedgerOptions = options;

            return BuildLedgerValues();
        }

        protected abstract Dictionary<LedgerAnnualValuesType,IList<LedgerValue<T>>> BuildLedgerValues();
    }

    public enum LedgerAnnualValuesType
    {
        Other = 0,
        CurrentValues = 1,
        ProjectedValues = 2,
        GuaranteedValues = 3
        
    }

}
