using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Web.Middleware
{
   public class DebuggingMiddleware
    {

        public readonly RequestDelegate _next;

        public DebuggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            var elapsedTime = stopwatch.Elapsed;
        }
    }
}
