using System;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Notifications;
using Backend.Domain.Core.Queries;
using Backend.Domain.Core.Results;
using Serilog;

namespace Backend.Domain.Core.Bus
{
    public class Bus : IBus
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INotificationHandler _notificationHandler;

        public Bus(IServiceProvider serviceProvider, INotificationHandler notificationHandler)
        {
            _serviceProvider = serviceProvider;
            _notificationHandler = notificationHandler;
        }

        public void Notify(Notification notification)
        {
            _notificationHandler.Handle(notification);
        }

        public AbstractOperationResult<TResult> Request<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            try
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
                return ExecuteHandler<TResult>(handlerType, query, queryType);
            }
            catch (Exception ex)
            {
                return HandleRequestException<TResult>(ex, queryType, false);
            }
        }

        public AbstractOperationResult<TResult> Submit<TResult>(ICommand<TResult> command)
        {
            var commandType = command.GetType();
            try
            {
                var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult));
                return ExecuteHandler<TResult>(handlerType, command, commandType);
            }
            catch (Exception ex)
            {
                return HandleSubmitException<TResult>(ex, commandType, true);
            }
        }

        private AbstractOperationResult<TResult> ExecuteHandler<TResult>(Type handlerType, object argument, Type argumentType)
        {
            var handler = _serviceProvider.GetService(handlerType);
            if (handler == null)
            {
                throw new ArgumentException("Handler not registered for type " + argumentType.Name);
            }
            var handleMethod = handlerType.GetMethod("Handle", new[] { argumentType });
            return ((AbstractOperationResult<TResult>)handleMethod.Invoke(handler, new[] { argument })).SetType(argumentType);
        }

        private SuccessOperationResult<TResult> HandleRequestException<TResult>(Exception ex, Type argumentType, bool notify)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            var message = ex.Message;
            Log.Error(ex, "Unexpected Error {@data}");
            if (notify)
            {
                Notify(new Notification(argumentType, "unexpected error"));
            }
            return (SuccessOperationResult<TResult>)new SuccessOperationResult<TResult>(message, default).SetType(argumentType);
        }

        private FailureOperationResult<TResult> HandleSubmitException<TResult>(Exception ex, Type argumentType, bool notify)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            var message = ex.Message;
            Log.Error(ex, "Unexpected Error {@data}");
            if (notify)
            {
                Notify(new Notification(argumentType, "unexpected error"));
            }
            return (FailureOperationResult<TResult>)new FailureOperationResult<TResult>(message, default).SetType(argumentType);
        }
    }
}
