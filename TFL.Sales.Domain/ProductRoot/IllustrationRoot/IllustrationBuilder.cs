using System.Collections.Generic;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;

namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot
{
    public interface IIllustrationBuilder<T> where T: Product
    {
        Dictionary<ProductIllustrationAnnualValuesType,IList<IllustrationValue<T>>> GenerateIllustration(ProductIllustrationOptions<T> options);
    }

    public abstract class IllustrationBuilder<T> : IIllustrationBuilder<T> where T : Product
    {
        protected ProductIllustrationOptions<T> IllustrationOptions;

        public Dictionary<ProductIllustrationAnnualValuesType,IList<IllustrationValue<T>>> GenerateIllustration(ProductIllustrationOptions<T> options)
        {
            IllustrationOptions = options;

            return BuildProductIllustration();
        }

        protected abstract Dictionary<ProductIllustrationAnnualValuesType,IList<IllustrationValue<T>>> BuildProductIllustration();
    }

    public enum ProductIllustrationAnnualValuesType
    {
        Other = 0,
        CurrentValues = 1,
        ProjectedValues = 2,
        GuaranteedValues = 3
        
    }

}
