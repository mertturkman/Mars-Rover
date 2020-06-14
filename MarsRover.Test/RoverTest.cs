using MarsRover.Domain.Enums;
using System.Drawing;
using Xunit;
using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Test.DataGeneretors;
using MarsRover.Domain.Exceptions;

namespace MarsRover.Test
{
    public class RoverTest
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public RoverTest(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;

        }

        [Theory]
        [ClassData(typeof(TestAcceptanceDataGenerator))]
        public void Test_Acceptance_Result_When_Rover_Move(Point inPosition, Size Plateau, string inDirection, 
            string inMovementList, Point outPoint, Direction outDirection)
        {
            DefineRoverCommand defineRoverCommand = new DefineRoverCommand(inPosition, Plateau, inDirection);
            _commandDispatcher.Handle(defineRoverCommand);

            MoveRoverCommand moveRoverCommand = new MoveRoverCommand(inMovementList);
            _commandDispatcher.Handle(moveRoverCommand);

            LocationInfoQuery locationInfoQuery = new LocationInfoQuery();
            string locationInfo = _queryDispatcher.Handle<LocationInfoQuery, string>(locationInfoQuery);
            string outputInfo = outPoint.X + " " + outPoint.Y + " " + outDirection.ToString("G");

            Assert.Equal(outputInfo, locationInfo);
        }

        [Theory]
        [ClassData(typeof(TestErrorDataGenerator))]
        public void Test_Error_Result_When_Rover_Move(Point inPosition, Size Plateau, string inDirection, 
            string inMovementList)
        {
            DefineRoverCommand defineRoverCommand = new DefineRoverCommand(inPosition, Plateau, inDirection);
            MoveRoverCommand moveRoverCommand = new MoveRoverCommand(inMovementList);
            _commandDispatcher.Handle(defineRoverCommand);
          
            Assert.Throws<PlateauException>(() => _commandDispatcher.Handle(moveRoverCommand));
        }
    }
}
