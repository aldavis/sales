using System;

namespace TFL.Sales.Domain.ProductRoot.IllustrationRoot
{
    public class PolicyIllustrationYear
    {
        public PolicyIllustrationYear(int value)
        {
            if(value <= 0) throw new Exception("Policy Illustration cannot have year 0");
            
            Value = value;
        }
        
        public int Value { get; }
    }
}