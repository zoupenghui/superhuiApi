using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superhui.Api.MiddelWare
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggerMiddleware (RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"request path: {context.Request.Path}\r\n");
            await context.Response.WriteAsync($"request path: {context.Request.Path}\r\n");

            await _next.Invoke(context);
            Console.WriteLine("finish request!");
            await context.Response.WriteAsync("finish request!\r\n");
        }
    }
}
