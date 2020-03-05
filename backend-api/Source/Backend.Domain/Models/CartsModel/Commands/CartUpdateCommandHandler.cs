using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel.Repositories;
using Backend.Domain.Models.ProductModel.Repositories;
using System.Linq;

namespace Backend.Infra.Repositories
{
    public sealed class CartUpdateCommandHandler : CommandHandler<CartUpdateCommand, Cart>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartUpdateCommandHandler(IBus bus, ICartRepository cartRepository, IProductRepository productRepository)
            : base(bus)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public override AbstractOperationResult<Cart> Handle(CartUpdateCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("error updating cart");
            }

            if (!_cartRepository.ExistsById(command.id.ToString()))
            {
                return new FailureOperationResult<Cart>("cart with specified id does not exists");
            }

            if (!_productRepository.ExistsBySku(command.item.sku))
            {
                return new FailureOperationResult<Cart>("product with specified sku does not exists");
            }

            var cart = _cartRepository.GetById(command.id.ToString()).Result;

            if ("CANCEL".Equals(cart.status))
            {
                return new FailureOperationResult<Cart>("cart is canceled");
            }

            if ("DONE".Equals(cart.status))
            {
                return new FailureOperationResult<Cart>("cart is done");
            }

            var product = _productRepository.GetBySku(command.item.sku).Result;

            var item = new CartItem(product);
            item.price = command.item.quantity * product.price.amount;

            if (cart.items.Any(x => x.id == item.id))
            {
                cart.items.Remove(item);
            }

            cart.items.Add(item);

            _cartRepository.Update(cart).Wait();

            var py = _cartRepository.GetAll().Result;
            var px = _cartRepository.GetByCustomerId(cart.customerId).Result;

            return new SuccessOperationResult<Cart>("cart updated", cart);
        }
    }
}
