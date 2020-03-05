using System;
using Backend.Domain.Core.Events;

namespace Backend.Domain.Core.Notifications
{
    public class Notification : Event, INotification
    {
        public Notification(Type type, string message, int version = 1)
            : base(type, message, version)
        {
            
        }
    }
}
