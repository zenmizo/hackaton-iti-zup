using Hackaiti.CheckoutService.Worker.Model;

namespace Hackaiti.CheckoutService.Worker.Services
{
    public interface ICartService
    {
        Cart GetCartById(string id);
    }
}