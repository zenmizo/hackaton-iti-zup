using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel.Repositories;

namespace Backend.Infra.Repositories
{
    public sealed class CartDeleteCommandHandler : CommandHandler<CartDeleteCommand, Cart>
    {
        private readonly ICartRepository _cartRepository;

        public CartDeleteCommandHandler(IBus bus, ICartRepository cartRepository)
            : base(bus)
        {
            _cartRepository = cartRepository;
        }

        public override AbstractOperationResult<Cart> Handle(CartDeleteCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("error deleting cart");
            }

            if (!_cartRepository.ExistsById(command.id.ToString()))
            {
                return new FailureOperationResult<Cart>("cart with specified id does not exists");
            }

            _cartRepository.Delete(command.id.ToString()).Wait();

            return new SuccessOperationResult<Cart>("cart deleted");
        }
    }
}
