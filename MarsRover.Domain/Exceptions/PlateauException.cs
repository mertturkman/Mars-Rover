using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Exceptions
{
    public class PlateauException: DomainException
    {
        public PlateauException()
        { }

        public PlateauException(string message) : base(message)
        { }

        public PlateauException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
