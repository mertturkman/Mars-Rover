using MarsRover.Domain;
using MarsRover.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Commands
{
    public class MoveRoverCommand : ICommand
    {
        public string _movementList { get; set; }

        public MoveRoverCommand(string movementList)
        {
            _movementList = movementList;
        }
    }
}
