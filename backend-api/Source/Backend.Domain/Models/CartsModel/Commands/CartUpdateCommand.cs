using Backend.Domain.Models.CartModelModel.Commands;
using System;

namespace Backend.Domain.Models.CartModel.Commands
{
    public sealed class CartUpdateCommand : CartCommand
    {
        public CartUpdateCommand(string id, CartEditItem item)
            : base(Guid.Parse(id), item)
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateItem();

            return Validate(Validator, this);
        }
    }
}
