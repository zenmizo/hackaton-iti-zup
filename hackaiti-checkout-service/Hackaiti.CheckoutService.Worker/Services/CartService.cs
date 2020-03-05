using Hackaiti.CheckoutService.Worker.Model;

namespace Hackaiti.CheckoutService.Worker.Services
{
    public class CartService : ICartService
    {
        public Cart GetCartById(string id)
        {
            return new Cart()
            {
                CustomerId = "1234",
                DesiredCurrencyCode = "BRL",
                Id = "42-42-42",
                Status = "PEDING",
                Items = new[]
                {
                    new CartItem()
                    {
                        Price = 1000,
                        Scale = 2,
                        CurrencyCode = "EUR"
                    },
                    new CartItem()
                    {
                        Price = 2000,
                        Scale = 2,
                        CurrencyCode = "BRL"
                    },
                    new CartItem()
                    {
                        Price = 30000,
                        Scale = 3,
                        CurrencyCode = "USD"
                    }
                }
            };
        }
    }
}