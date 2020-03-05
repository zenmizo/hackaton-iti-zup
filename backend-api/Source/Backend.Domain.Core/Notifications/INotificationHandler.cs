using System.Collections.Generic;

namespace Backend.Domain.Core.Notifications
{
    public interface INotificationHandler
    {
        List<Notification> Notifications { get; }
        void Handle(Notification notification);
        bool HasNotifications();
    }
}
