using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.ProductModel;
using Backend.Domain.Models.ProductModel.Commands;
using Backend.Domain.Models.ProductModel.Repositories;

namespace Backend.Infra.Repositories
{
    public sealed class ProductCreateCommandHandler : CommandHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IBus bus, IProductRepository productRepository)
            : base(bus)
        {
            _productRepository = productRepository;
        }

        public override AbstractOperationResult<Product> Handle(ProductCreateCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Product>("error creating product");
            }

            var entity = new Product(command.id)
            {
                sku = command.sku,
                name = command.name,
                shortDescription = command.shortDescription,
                longDescription = command.longDescription,
                imageUrl = command.imageUrl,
                price = command.price
            };

            if (_productRepository.ExistsBySku(command.sku))
            {
                return new FailureOperationResult<Product>("product with specified sku already exists");
            }

            _productRepository.Add(entity).Wait();

            var py = _productRepository.GetAll().Result;
            var px = _productRepository.GetBySku(entity.sku).Result;

            return new SuccessOperationResult<Product>("product created", entity);
        }
    }
}
