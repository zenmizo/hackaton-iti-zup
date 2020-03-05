using Backend.Domain.Core.Queries;

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
