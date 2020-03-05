using Backend.Domain.Core.Commands;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Validators;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Domain.Models.CartModelModel.Commands
{
    public abstract class CartCommand : Command<Guid, Cart, Cart>
    {
        public string xTeamControl { get; set; }
        public string currencyCode { get; set; }

        public string customerId { get; set; }
        public string status { get; set; }
        public CartEditItem item { get; set; }
        public List<CartItem> items { get; set; }

        protected readonly CartValidator Validator;

        protected CartCommand(Guid id, Expression<Func<Cart, bool>> filter = null)
            : base(id, filter)
        {
            Validator = new CartValidator();
        }

        protected CartCommand(Cart cart)
            : this(Guid.NewGuid())
        {
            customerId = cart.customerId;
            status = cart.status;
            item = cart?.item ?? new CartEditItem();
            items = cart?.items ?? new List<CartItem>();
        }

        protected CartCommand(Guid id, CartEditItem Item)
            : this(id)
        {
            item = Item ?? new CartEditItem();
        }
    }
}
