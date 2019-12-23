using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Providers
{
    public class CorrelationIdAccessor : ICorrelationIdAccessor
    {
        private readonly ILogger<CorrelationIdAccessor> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CorrelationIdHeader = "X-Correlation-ID";
        private const string CorrelationIdLogName = "CorrelationId";

        public CorrelationIdAccessor(ILogger<CorrelationIdAccessor> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get()
        {
            try
            {
                var context = this._httpContextAccessor.HttpContext;
                var result = context?.Items[CorrelationIdHeader] as string;

                return result;
            }
            catch (Exception exception)
            {
                this._logger.LogWarning(exception, $"No {CorrelationIdLogName} was found");
            }

            return string.Empty;
        }

        public void Set(string correlationId)
        {
            try
            {
                _httpContextAccessor.HttpContext.Items[CorrelationIdHeader] = correlationId;
            }
            catch (Exception exception)
            {
                _logger.LogWarning(exception, $"HttpContext is null, unable to set {CorrelationIdLogName} {correlationId}");
            }
        }
    }
}
