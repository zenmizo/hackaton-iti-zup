using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Notifications;
using Backend.Domain.Core.Results;

namespace Backend.Domain.Core.Commands
{
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
    {
        protected readonly IBus Bus;

        protected CommandHandler(IBus bus)
        {
            Bus = bus;
        }

        public abstract AbstractOperationResult<TResult> Handle(TCommand command);

        protected void NotifyValidationErrors(TCommand command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                Bus.Notify(new Notification(command.GetType(), error.ErrorMessage));
            }
        }
    }
}
