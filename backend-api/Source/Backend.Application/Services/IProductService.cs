using Backend.Application.Results;
using Backend.Domain.Models.ProductModel;

namespace Backend.Application.Services
{
    public interface IProductService
    {
        AbstractApiResult GetAll();
        AbstractApiResult GetById(string id);
        AbstractApiResult GetBySku(string sku);
        AbstractApiResult Create(Product product);
    }
}
