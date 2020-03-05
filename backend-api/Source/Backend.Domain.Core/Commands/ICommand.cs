using FluentValidation.Results;

namespace Backend.Domain.Core.Commands
{
    public interface ICommand
    {
        object id { get; set; }
        ValidationResult ValidationResult { get; set; }
        bool IsValid();
    }

    public interface ICommand<TResult> : ICommand
    {
        
    }
}
