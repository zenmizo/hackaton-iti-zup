using Backend.Domain.Core.Results;

namespace Backend.Domain.Core.Commands
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand
    {
        AbstractOperationResult<TResult> Handle(TCommand command);
    }
}
