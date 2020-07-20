using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Queries
{
   public interface IQueryHandler<TQuery, TResult> where TQuery :IQuery<TResult>
    {
        TResult Handle(TQuery query);

    }
}
