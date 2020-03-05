using Backend.Domain.Core.Queries;
using System.Collections.Generic;

namespace Backend.Domain.Models.CartModel.Queries
{
    public sealed class CartGetAllQuery : Query<Cart, List<Cart>>
    {
        public CartGetAllQuery()
            : base(null)
        {

        }
    }
}
