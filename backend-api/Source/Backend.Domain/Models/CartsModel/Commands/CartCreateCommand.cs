using Backend.Domain.Models.CartModelModel.Commands;

namespace Backend.Domain.Models.CartModel.Commands
{
    public sealed class CartCreateCommand : CartCommand
    {
        public CartCreateCommand(Cart cart)
            : base(cart)
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateCustomerId();
            Validator.ValidateItem();

            return Validate(Validator, this);
        }
    }
}
