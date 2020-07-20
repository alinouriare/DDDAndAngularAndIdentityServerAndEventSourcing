using Application.Common.Commands;
using Application.Common.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    internal static class Utils
    {
        public static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
            {
                return false;
            }

            var typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>)
                || typeDefinition == typeof(IQueryHandler<,>);
        }
    }
}
