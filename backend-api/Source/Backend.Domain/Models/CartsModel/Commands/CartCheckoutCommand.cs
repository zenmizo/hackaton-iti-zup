using Backend.Domain.Models.CartModelModel.Commands;
using System;

namespace Backend.Domain.Models.CartModel.Commands
{
    public sealed class CartCheckoutCommand : CartCommand
    {
        public CartCheckoutCommand(string id, string CurrencyCode, string XTeamControl)
            : base(Guid.Parse(id))
        {
            xTeamControl = XTeamControl;
            currencyCode = CurrencyCode;
        }

        public override bool IsValid()
        {
            Validator.ValidateId();
            Validator.ValidateXTeamControl();

            return Validate(Validator, this);
        }
    }
}
