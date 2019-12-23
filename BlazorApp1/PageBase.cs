using Logging.Providers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public class PageBase : ComponentBase
    {
        [Inject] ICorrelationIdAccessor CorrelationIdAccessor { get; set; }

        protected void EnsureNewCorrelationId()
        {
            var correlationId = Guid.NewGuid().ToString();
            CorrelationIdAccessor.Set(correlationId);
        }
    }
}
