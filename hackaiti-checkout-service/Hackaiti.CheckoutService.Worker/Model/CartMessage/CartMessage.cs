namespace Hackaiti.CheckoutService.Worker.Model.CartMessage
{
    public class CartMessage
    {
        public CartInvoice Invoice { get; set; }
        public Cart Cart { get; set; }
    }
}