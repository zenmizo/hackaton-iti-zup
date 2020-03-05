using Backend.Application.Results;
using Backend.Domain.Models.CartModel;

namespace Backend.Application.Services
{
    public interface ICartService
    {
        AbstractApiResult GetAll();
        AbstractApiResult GetById(string id);
        AbstractApiResult GetByCustomerId(string id);
        AbstractApiResult Create(Cart cart);
        AbstractApiResult Update(string id, CartEditItem item);
        AbstractApiResult Delete(string id);
        AbstractApiResult DeleteItem(string id, string item_id);
    }
}
