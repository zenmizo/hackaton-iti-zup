using Backend.Domain.Core.Queries;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.ProductModel.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Domain.Models.ProductModel.Queries
{
    public sealed class ProductGetAllQueryHandler : QueryHandler<ProductGetAllQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public ProductGetAllQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public override AbstractOperationResult<List<Product>> Handle(ProductGetAllQuery query)
        {
            var result = _repository.GetAll().Result.ToList();

            return new SuccessOperationResult<List<Product>>(result);
        }
    }
}
