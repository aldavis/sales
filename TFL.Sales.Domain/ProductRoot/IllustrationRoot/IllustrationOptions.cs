using System.Collections.Generic;

namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot
{
    public class ProductIllustrationOptions<T> where T : Product 
    {
        public ProductIllustrationOptions( T product,int insuredAgeForIllustration, string insuredGender,params ProductIllustrationAnnualValuesType[] illustrationValuesTypes)
        {
            Product = product;
            InsuredAgeForIllustration = insuredAgeForIllustration;
            InsuredGender = insuredGender;
            IllustrationValuesTypes = illustrationValuesTypes;

        }
        
        public T Product { get; }
        
        public int InsuredAgeForIllustration { get; }
        
        public string InsuredGender { get; }
        
        public IList<ProductIllustrationAnnualValuesType> IllustrationValuesTypes { get; }
    }
}
