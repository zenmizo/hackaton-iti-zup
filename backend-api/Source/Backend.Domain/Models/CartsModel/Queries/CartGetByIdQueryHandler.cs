using Backend.Domain.Core.Queries;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel.Repositories;

namespace Backend.Domain.Models.CartModel.Queries
{
    public sealed class CartGetByIdQueryHandler : QueryHandler<CartGetByIdQuery, Cart>
    {
        private readonly ICartRepository _repository;

        public CartGetByIdQueryHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Cart> Handle(CartGetByIdQuery query)
        {
            var result = _repository.GetById(query.Id.ToString()).Result;

            return new SuccessOperationResult<Cart>(result);
        }
    }
}
