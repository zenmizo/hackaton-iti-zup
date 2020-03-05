using Backend.Domain.Core.Queries;
using System.Collections.Generic;

namespace Backend.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetAllQuery : Query<Product, List<Product>>
    {
        public ProductGetAllQuery()
            : base(null)
        {

        }
    }
}
