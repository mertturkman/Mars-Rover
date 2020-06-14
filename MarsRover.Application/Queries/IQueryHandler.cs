using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Queries
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        TResult Query(TQuery query);
    }
}
