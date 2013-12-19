using System;
using Autofac;
using PingPongPro.Domain;

namespace PinPongPro.Presentation.Infrastructure
{
    public class AutoFacCommandDispatcher : ICommandDispatcher
    {
        readonly ILifetimeScope _lifetimeScope;

        public AutoFacCommandDispatcher(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        dynamic GetProcessorToHandleCommand(ICommand command)
        {
            Type commandProcessorType = typeof(ICommandHandler<>);
            Type genericType = commandProcessorType.MakeGenericType(new[] { command.GetType() });

            if (!_lifetimeScope.IsRegistered(genericType))
                throw new Exception(string.Format("Comand {0} is not registred", command.GetType().Name));

            return _lifetimeScope.Resolve(genericType);
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            dynamic processor = GetProcessorToHandleCommand(command);
            processor.Procces((dynamic)command);
        }
    }
}