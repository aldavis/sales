using System;

namespace TFL.Sales.Domain.ProductRoot
{
	public abstract class Product
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        public abstract ProductLineOfBusiness LineOfBusiness { get; }

	}

    public enum ProductLineOfBusiness
    {
        Term = 1,
        Whole = 2,
        Universal = 3
    }

}
