using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Commands
{
    public interface ICommandDispatcher
    {
        void Handle<TCommand>(TCommand command) where TCommand : ICommand;  
    }
}
