namespace Hackaiti.CheckoutService.Worker.Model
{
    public class CartItem
    {
        public string Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public long Price { get; set; }
        public long Scale { get; set; }
        public string CurrencyCode { get; set; }
    }
}