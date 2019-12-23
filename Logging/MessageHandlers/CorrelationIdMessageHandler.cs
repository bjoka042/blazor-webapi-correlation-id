using Logging.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logging.MessageHandlers
{
    public class CorrelationIdMessageHandler : DelegatingHandler
    {
        private readonly ICorrelationIdAccessor _correlationIdAccessor;
        private readonly ILogger<CorrelationIdMessageHandler> _logger;
        private const string CorrelationIdHeader = "X-Correlation-ID";
        private const string CorrelationIdLogName = "CorrelationId";

        public CorrelationIdMessageHandler(ICorrelationIdAccessor correlationIdAccessor, ILogger<CorrelationIdMessageHandler> logger)
        {
            _correlationIdAccessor = correlationIdAccessor;
            _logger = logger;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdAccessor.Get();
            if (string.IsNullOrEmpty(correlationId))
            {
                _logger.LogWarning($"No {CorrelationIdLogName} was found");
            }
            else 
            {
                request.Headers.Add(CorrelationIdHeader, correlationId);
                _logger.LogDebug($"Adding {CorrelationIdLogName} {correlationId} to headers");
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
