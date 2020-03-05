using Backend.Domain.Core.Queries;
using System.Collections.Generic;

namespace Backend.Domain.Models.CartModel.Queries
{
    public sealed class CartGetByCustomerIdQuery : Query<Cart, Cart>
    {
        public CartGetByCustomerIdQuery(string customerId)
            : base(customerId)
        {

        }
    }
}
