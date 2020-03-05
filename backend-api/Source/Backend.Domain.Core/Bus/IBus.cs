using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Notifications;
using Backend.Domain.Core.Queries;
using Backend.Domain.Core.Results;

namespace Backend.Domain.Core.Bus
{
    public interface IBus
    {
        void Notify(Notification notification);
        AbstractOperationResult<TResult> Request<TResult>(IQuery<TResult> query);
        AbstractOperationResult<TResult> Submit<TResult>(ICommand<TResult> command);
    }
}
