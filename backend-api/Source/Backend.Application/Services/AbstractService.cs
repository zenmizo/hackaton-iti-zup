using Backend.Application.Results;
using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Backend.Application.Services
{
    public abstract class AbstractService
    {
        protected readonly IBus Bus;
        protected readonly INotificationHandler NotificationHandler;

        public AbstractService(IBus bus, INotificationHandler notificationHandler)
        {
            Bus = bus;
            NotificationHandler = notificationHandler;
        }

        public IList<string> GetNotifications() => NotificationHandler.Notifications.Select(x => x.Message).ToList();
        public AbstractApiResult ValidationErrorResult() => new FailureApiResult(HttpStatusCode.BadRequest,  GetNotifications());
    }
}
