using System;
using TFL.Infrastructure.WebApi.Contracts;
using TFL.Sales.Domain.ProductRoot;

namespace TFL.Sales.Application.Features.Products
{
    public class CalculateProductLedgerRequest : ApiRequest
    {
        public Guid ProductId { get; set; }

        public ProductLineOfBusiness ProductLineOfBusiness { get; set; }

        public decimal FaceAmount { get; set; }

        public int InsuredAge { get; set; }

        public string InsuredGender { get; set; }
    }
}