using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Commands
{
    public class DefineRoverCommandHandler : ICommandHandler<DefineRoverCommand>
    {
        private IRover _rover;
        public DefineRoverCommandHandler(IRover rover)
        {
            _rover = rover;
        }

        public void Execute(DefineRoverCommand command)
        {
            _rover.Define(command._plateau, command._position, command._direction);
        }
    }
}
