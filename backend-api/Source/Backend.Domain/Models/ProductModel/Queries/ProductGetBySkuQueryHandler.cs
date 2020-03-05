using Backend.Domain.Core.Queries;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.ProductModel.Repositories;

namespace Backend.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetBySkuQueryHandler : QueryHandler<ProductGetBySkuQuery, Product>
    {
        private readonly IProductRepository _repository;

        public ProductGetBySkuQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<Product> Handle(ProductGetBySkuQuery query)
        {
            var result = _repository.GetBySku(query.Id.ToString()).Result;

            return new SuccessOperationResult<Product>(result);
        }
    }
}
