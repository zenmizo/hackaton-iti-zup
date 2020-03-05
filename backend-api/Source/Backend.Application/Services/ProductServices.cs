using Backend.Application.Results;
using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Notifications;
using Backend.Domain.Models.ProductModel;
using Backend.Domain.Models.ProductModel.Commands;
using Backend.Domain.Models.ProductModel.Queries;
using System.Net;

namespace Backend.Application.Services
{
    public class ProductService : AbstractService, IProductService
    {
        public ProductService(IBus bus, INotificationHandler notificationHandler)
            : base(bus, notificationHandler)
        {

        }

        public AbstractApiResult GetAll()
        {
            var query = new ProductGetAllQuery();
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult GetById(string id)
        {
            var query = new ProductGetByIdQuery(id);
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult GetBySku(string sku)
        {
            var query = new ProductGetBySkuQuery(sku);
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Create(Product product)
        {
            var command = new ProductCreateCommand(product);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.Created, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }
    }
}
