using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.ConsoleApp
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            AddHandlers(services, typeof(ICommandHandler<>));
            AddHandlers(services, typeof(IQueryHandler<,>));
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddSingleton<IRover, Rover>();
        }
        public static void AddHandlers(IServiceCollection services, Type handlerInterface)
        {
            var handlers = typeof(LocationInfoQuery).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == handlerInterface)
            );

            foreach (var handler in handlers)
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == handlerInterface), handler);
        }
    }
}
