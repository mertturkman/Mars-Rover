using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public void Handle<TCommand>(TCommand command) where TCommand : ICommand
        {
            var service = this._serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
            service.Execute(command);
        }
    }
}
