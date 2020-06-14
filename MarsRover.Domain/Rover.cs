using MarsRover.Domain.Enums;
using MarsRover.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class Rover: IRover
    {
        private IPlateau _plateau;
        private IPosition _position;
        private Direction _direction;

        public Rover() 
        { }
        
        public void Define(IPlateau plateau, IPosition position, Direction direction)
        {
            _plateau = plateau;
            _position = position;
            _direction = direction;
        }

        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.M:
                    GoAhead();
                    break;
                case Movement.L:
                    RotateLeft();
                    break;
                case Movement.R:
                    RotateRight();
                    break;
            }
        }

        private void GoAhead()
        {
            switch (_direction)
            {
                case Direction.N:
                    if (_position.Y + 1 <= _plateau.Dimension.Height)
                        _position.Y++;
                    else
                        throw new PlateauException("Y coordinate exceeded the limit.");
                    break;
                case Direction.E:
                    if(_position.X + 1 <= _plateau.Dimension.Width)
                        _position.X++;
                    else
                        throw new PlateauException("X coordinate exceeded the limit.");
                    break;
                case Direction.S:
                    if (_position.Y - 1 >= 0)
                        _position.Y--;
                    else
                        throw new PlateauException("Y coordinate can not negative.");
                    break;
                case Direction.W:
                    if (_position.X - 1 >= 0)
                        _position.X--;
                    else
                        throw new PlateauException("X coordinate can not negative.");
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (_direction)
            {
                case Direction.S:
                    _direction = Direction.E;
                    break;
                case Direction.N:
                    _direction = Direction.W;
                    break;
                case Direction.W:
                    _direction = Direction.S;
                    break;
                case Direction.E:
                    _direction = Direction.N;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (_direction)
            {
                case Direction.S:
                    _direction = Direction.W;
                    break;
                case Direction.N:
                    _direction = Direction.E;
                    break;
                case Direction.E:
                    _direction = Direction.S;
                    break;
                case Direction.W:
                    _direction = Direction.N;
                    break;
            }
        }

        public string LocationInfo()
        {
            return _position.X + " " + _position.Y + " " + _direction.ToString("G");
        }
    }
}
