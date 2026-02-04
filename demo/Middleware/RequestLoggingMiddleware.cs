using demo.Middleware;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace demo.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Request received: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            stopwatch.Stop();

            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Response: {context.Response.StatusCode} - Completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}


public static class Logger
{
    //to enable chaining i am returning this , which is a pipeline builder
    public static IApplicationBuilder UseLogger(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }
    //useMiddlewer to register our custom middleware into req pipeline
}