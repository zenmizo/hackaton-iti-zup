using Backend.Application.Results;
using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Notifications;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel.Queries;
using System.Net;

namespace Backend.Application.Services
{
    public class CartService : AbstractService, ICartService
    {
        public CartService(IBus bus, INotificationHandler notificationHandler)
            : base(bus, notificationHandler)
        {

        }

        public AbstractApiResult GetAll()
        {
            var query = new CartGetAllQuery();
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult GetById(string id)
        {
            var query = new CartGetByIdQuery(id);
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult GetByCustomerId(string customerId)
        {
            var query = new CartGetByCustomerIdQuery(customerId);
            var result = Bus.Request(query);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Create(Cart cartCreate)
        {
            var command = new CartCreateCommand(cartCreate);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.Created, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Update(string id, CartEditItem item)
        {
            var command = new CartUpdateCommand(id, item);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Delete(string id)
        {
            var command = new CartDeleteCommand(id);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.NoContent, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult DeleteItem(string id, string item_id)
        {
            var command = new CartDeleteItemCommand(id, item_id);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.NoContent, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }

        public AbstractApiResult Checkout(string id, string currencyCode, string xTeamControl)
        {
            var command = new CartCheckoutCommand(id, currencyCode, xTeamControl);
            var result = Bus.Submit(command);

            if (NotificationHandler.HasNotifications()) return ValidationErrorResult();

            return result.Success
                ? (AbstractApiResult)new SuccessApiResult(HttpStatusCode.OK, result.Data)
                : (AbstractApiResult)new FailureApiResult(HttpStatusCode.BadRequest, result.Message);
        }
    }
}
