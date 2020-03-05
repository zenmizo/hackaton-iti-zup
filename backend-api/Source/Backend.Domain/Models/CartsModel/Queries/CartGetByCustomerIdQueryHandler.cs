using Backend.Domain.Core.Queries;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel.Repositories;

namespace Backend.Domain.Models.CartModel.Queries
{
    public sealed class CartGetByCustomerIdQueryHandler : QueryHandler<CartGetByCustomerIdQuery, Cart>
    {
        private readonly ICartRepository _repository;

        public CartGetByCustomerIdQueryHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Cart> Handle(CartGetByCustomerIdQuery query)
        {
            var result = _repository.GetByCustomerId(query.Id.ToString()).Result;

            return new SuccessOperationResult<Cart>(result);
        }
    }
}
