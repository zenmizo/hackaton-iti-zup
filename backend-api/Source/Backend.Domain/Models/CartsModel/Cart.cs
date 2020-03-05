using Backend.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace Backend.Domain.Models.CartModel
{
    public class Cart : Entity<Guid>
    {
        public static List<Cart> Carts = new List<Cart>();

        public Cart()
        {
            items = new List<CartItem>();
        }

        public Cart(Guid id)
            : base(id)
        {
            items = new List<CartItem>();
        }

        public string customerId { get; set; }
        public string status { get; set; }
        public CartEditItem item { internal get; set; }
        public List<CartItem> items { get; set; }
    }

    public class CartCheckoutBody
    { 
        public string currencyCode { get; set; }
    }
}
