using System.Collections.Generic;

namespace Hackaiti.CheckoutService.Worker.Model.CartMessage
{
    public class Cart
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public IEnumerable<CartItem> Items { get; set; }
    }
}