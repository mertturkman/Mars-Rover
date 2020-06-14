using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly  IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public TResult Handle<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var service = this._serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>)) as IQueryHandler<TQuery, TResult>;
            return service.Query(query);
        }
    }
}
