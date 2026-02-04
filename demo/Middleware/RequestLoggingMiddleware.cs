using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace demo.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Request: {context.Request.Method} {context.Request.Path}");
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Request received: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            stopwatch.Stop();

            _logger.LogInformation($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Response: {context.Response.StatusCode} - Completed in {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Response: {context.Response.StatusCode} - Completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
