using MarsRover.Domain;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Commands
{
    public class MoveRoverCommandHandler : ICommandHandler<MoveRoverCommand>
    {
        private IRover _rover;
        public MoveRoverCommandHandler(IRover rover)
        {
            _rover = rover;
        }
        public void Execute(MoveRoverCommand command)
        {
            foreach (char movementItem in command._movementList)
            {
                Movement movement;
                try
                {
                    movement = (Movement)Enum.Parse(typeof(Movement), movementItem.ToString());
                }
                catch (Exception ex)
                {
                    throw new DirectionException(ex.Message, ex.InnerException);
                }
                _rover.Move(movement);
            }
        }
    }
}
