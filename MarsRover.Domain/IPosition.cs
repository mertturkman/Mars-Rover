using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MarsRover.Domain
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
    }
}
