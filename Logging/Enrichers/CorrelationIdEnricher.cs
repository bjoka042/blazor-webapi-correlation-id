using Logging.Providers;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Enrichers
{
    public class CorrelationIdEnricher : ILogEventEnricher
    {
        private readonly ICorrelationIdAccessor _correlationIdAccessor;
        private const string CorrelationIdLogName = "CorrelationId";

        public CorrelationIdEnricher(ICorrelationIdAccessor correlationIdAccessor)
        {
            _correlationIdAccessor = correlationIdAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(new LogEventProperty(CorrelationIdLogName, new ScalarValue(_correlationIdAccessor.Get())));
        }
    }
}
