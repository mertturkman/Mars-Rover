using System;
using System.Drawing;

namespace MarsRover.Domain
{
    public class Position: IPosition
    {
        private Point _point;

        public Position(Point point) 
        {
            _point = point;
        }

        public int X
        {
            get { return _point.X; }
            set { _point.X = value; }
        }

        public int Y
        {
            get { return _point.Y; }
            set { _point.Y = value; }
        }
    }
}
