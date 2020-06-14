using MarsRover.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public interface IRover
    {
        void Define(IPlateau plateau, IPosition position, Direction direction);
        void Move(Movement movement);
        string LocationInfo();
    }
}
