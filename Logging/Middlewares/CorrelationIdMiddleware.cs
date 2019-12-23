using Logging.Enrichers;
using Logging.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Serilog;
using Serilog.Context;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Logging.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string CorrelationIdHeaderName = "X-Correlation-ID";
        private const string CorrelationIdLogName = "CorrelationId";

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<CorrelationIdMiddleware> logger, ICorrelationIdAccessor correlationIdAccessor)
        {
            var correlationIdCreated = false;

            var correlationId = context.Request.Headers[CorrelationIdHeaderName];
            if (correlationId == StringValues.Empty)
            {
                correlationId = Guid.NewGuid().ToString();
                correlationIdCreated = true;
            }

            correlationIdAccessor.Set(correlationId.ToString());

            if (correlationIdCreated)
            {
                logger.LogDebug($"No {CorrelationIdLogName} found in header. Adding new {CorrelationIdLogName} {correlationId} to context");
            }
            else
            {
                logger.LogDebug($"{CorrelationIdLogName} {correlationId} found in header and added to context");
            }

            await _next(context);
        }
    }
}
