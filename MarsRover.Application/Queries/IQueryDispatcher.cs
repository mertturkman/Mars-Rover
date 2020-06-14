using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Queries
{
    public interface IQueryDispatcher
    {
        TResult Handle<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
