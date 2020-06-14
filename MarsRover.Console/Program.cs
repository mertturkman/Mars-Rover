using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Linq;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ICommandDispatcher commandDispatcher = serviceProvider.GetService<ICommandDispatcher>();
            IQueryDispatcher queryDispatcher = serviceProvider.GetService<IQueryDispatcher>();

            RoverRunFirst(commandDispatcher, queryDispatcher);
            RoverRunSecond(commandDispatcher, queryDispatcher);
            Console.ReadKey();
        }

        static void RoverRunFirst(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            DefineRoverCommand defineRoverCommand = new DefineRoverCommand(new Point(1, 2), new Size(5, 5), "N");
            commandDispatcher.Handle(defineRoverCommand);

            MoveRoverCommand moveRoverCommand = new MoveRoverCommand("LMLMLMLMM");
            commandDispatcher.Handle(moveRoverCommand);

            LocationInfoQuery locationInfoQuery = new LocationInfoQuery();
            string locationInfo = queryDispatcher.Handle<LocationInfoQuery, string>(locationInfoQuery);
            Console.WriteLine(locationInfo);
        }

        static void RoverRunSecond(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            DefineRoverCommand defineRoverCommand = new DefineRoverCommand(new Point(3, 3), new Size(5, 5), "E");
            commandDispatcher.Handle(defineRoverCommand);

            MoveRoverCommand moveRoverCommand = new MoveRoverCommand("MMRMMRMRRM");
            commandDispatcher.Handle(moveRoverCommand);

            LocationInfoQuery locationInfoQuery = new LocationInfoQuery();
            string locationInfo = queryDispatcher.Handle<LocationInfoQuery, string>(locationInfoQuery);
            Console.WriteLine(locationInfo);
        }
    }
}
