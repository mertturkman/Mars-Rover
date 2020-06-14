using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Exceptions
{
    public class DirectionException: DomainException
    {
        public DirectionException()
        { }

        public DirectionException(string message) : base(message)
        { }

        public DirectionException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
