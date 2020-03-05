using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel.Repositories;
using Backend.Domain.Models.ProductModel.Repositories;
using System.Collections.Generic;

namespace Backend.Infra.Repositories
{
    public sealed class CartCheckoutCommandHandler : CommandHandler<CartCheckoutCommand, Cart>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartCheckoutCommandHandler(IBus bus, ICartRepository cartRepository, IProductRepository productRepository)
            : base(bus)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public override AbstractOperationResult<Cart> Handle(CartCheckoutCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("checkout error");
            }

            if (!_cartRepository.ExistsById(command.id.ToString()))
            {
                return new FailureOperationResult<Cart>("cart with specified id does not exists");
            }

            _cartRepository.Checkout(command.id.ToString()).Wait();

            return new SuccessOperationResult<Cart>("checkout complete");
        }
    }
}
