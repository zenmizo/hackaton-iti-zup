using Backend.Domain.Models.CartModelModel.Commands;
using System;

namespace Backend.Domain.Models.CartModel.Commands
{
    public sealed class CartDeleteItemCommand : CartCommand
    {
        public CartDeleteItemCommand(string id, string item_id)
            : base(Guid.Parse(id))
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateId();

            return Validate(Validator, this);
        }
    }
}
