using Logging.Enrichers;
using Logging.Providers;
using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Threading.Tasks;

namespace Logging.Middlewares
{
    public class CorrelationIdLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationIdLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICorrelationIdAccessor correlationIdAccessor)
        {
            using (LogContext.Push(new CorrelationIdEnricher(correlationIdAccessor)))
            {
                await _next(context);
            }
        }
    }
}
