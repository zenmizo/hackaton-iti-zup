using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel.Repositories;

namespace Backend.Infra.Repositories
{
    public sealed class CartDeleteItemCommandHandler : CommandHandler<CartDeleteItemCommand, Cart>
    {
        private readonly ICartRepository _cartRepository;

        public CartDeleteItemCommandHandler(IBus bus, ICartRepository cartRepository)
            : base(bus)
        {
            _cartRepository = cartRepository;
        }

        public override AbstractOperationResult<Cart> Handle(CartDeleteItemCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("error deleting item");
            }

            if (!_cartRepository.ExistsById(command.id.ToString()))
            {
                return new FailureOperationResult<Cart>("item with specified id does not exists");
            }

            _cartRepository.Delete(command.id.ToString()).Wait();

            return new SuccessOperationResult<Cart>("item deleted from cart");
        }
    }
}
