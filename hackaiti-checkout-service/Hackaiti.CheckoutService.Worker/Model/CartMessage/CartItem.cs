namespace Hackaiti.CheckoutService.Worker.Model.CartMessage
{
    public class CartItem
    {
        public string Id { get; set; }
        public long Price { get; set; }
        public long Scale { get; set; }
        public string CurrencyCode { get; set; }
        public CartProduct Product { get; set; }
    }
}