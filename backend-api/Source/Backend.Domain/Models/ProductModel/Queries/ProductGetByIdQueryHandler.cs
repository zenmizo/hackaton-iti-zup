using Backend.Domain.Core.Queries;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.ProductModel.Repositories;

namespace Backend.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetByIdQueryHandler : QueryHandler<ProductGetByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public ProductGetByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Product> Handle(ProductGetByIdQuery query)
        {
            var result = _repository.GetById(query.Id.ToString()).Result;

            return new SuccessOperationResult<Product>(result);
        }
    }
}
