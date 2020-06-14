using MarsRover.Domain;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Exceptions;
using System;
using System.Drawing;

namespace MarsRover.Application.Commands
{
    public class DefineRoverCommand : ICommand
    {
        public IPlateau _plateau { get; set; }
        public IPosition _position { get; set; }
        public Direction _direction { get; set; }

        public DefineRoverCommand(Point point, Size size, string direction)
        {
            _position = new Position(point);
            _plateau = new Plateau(size);

            try {
                _direction = (Direction)Enum.Parse(typeof(Direction), direction);
            }
            catch(Exception ex)
            {
                throw new DirectionException(ex.Message, ex.InnerException);
            }
            
        }
    }
}
