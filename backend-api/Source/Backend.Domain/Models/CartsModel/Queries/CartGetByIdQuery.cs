using Backend.Domain.Core.Queries;

namespace Backend.Domain.Models.CartModel.Queries
{
    public sealed class CartGetByIdQuery : Query<Cart, Cart>
    {
        public CartGetByIdQuery(string id)
            : base(id)
        {

        }
    }
}
