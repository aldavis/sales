using System.Collections.Generic;
using TFL.Sales.Domain.ProductRoot.IllustrationRoot.TermIllustrationRoot;

namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot
{
    public interface IProductIllustrationBuilder<T> where T: Product
    {
        IList<ProductIllustrationAnnualValue<T>> GenerateIllustration(ProductIllustrationOptions<T> options);
    }

    public abstract class ProductIllustrationBuilder<T> : IProductIllustrationBuilder<T> where T : Product
    {
        protected ProductIllustrationOptions<T> IllustrationOptions;

        public IList<ProductIllustrationAnnualValue<T>> GenerateIllustration(ProductIllustrationOptions<T> options)
        {
            IllustrationOptions = options;

            return GetValues();
        }

        protected abstract IList<ProductIllustrationAnnualValue<T>> GetValues();
    }

}
