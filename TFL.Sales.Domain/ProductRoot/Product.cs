using System;
using TFL.Sales.Domain.SharedKernel;

namespace TFL.Sales.Domain.ProductRoot
{
	public abstract class Product : Entity, IAggregateRoot
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        public int MaturityAge { get; set; }

        public int MinimumIssueAge { get; set; }

        public int MaximumIssueAge { get; set; }

        public abstract ProductLineOfBusiness LineOfBusiness { get; }

	}

    public enum ProductLineOfBusiness
    {
        Term = 1,
        Whole = 2,
        Universal = 3
    }

}
