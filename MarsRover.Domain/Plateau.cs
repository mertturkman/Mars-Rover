using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MarsRover.Domain
{
    public class Plateau :IPlateau
    {
        private Size _dimension;
        
        public Plateau(Size dimension) 
        {
            _dimension = dimension;
        }

        public Size Dimension
        {
            get { return _dimension; }
        }
    }
}
