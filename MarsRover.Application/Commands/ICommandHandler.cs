using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
