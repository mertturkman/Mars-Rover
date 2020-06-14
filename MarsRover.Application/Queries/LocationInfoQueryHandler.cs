using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Queries
{
    public class LocationInfoQueryHandler : IQueryHandler<LocationInfoQuery, string>
    {
        private IRover _rover;
        public LocationInfoQueryHandler(IRover rover)
        {
            _rover = rover;
        }
        public string Query(LocationInfoQuery query)
        {
            return _rover.LocationInfo();
        }
    }
}
