using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

[assembly: TestFramework("MarsRover.Test.Startup", "MarsRover.Test")]
namespace MarsRover.Test
{
    public class Startup : DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink) { }

        protected void ConfigureServices(IServiceCollection services)
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

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
    }
}
