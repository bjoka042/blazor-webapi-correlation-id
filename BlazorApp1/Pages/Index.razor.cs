using Logging.Enrichers;
using Logging.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class IndexBase : PageBase
    {
        [Inject] WebApplication1.Proxy.IService1 Service1 { get; set; }
        [Inject] ILogger<IndexBase> Logger { get; set; }

        protected async Task CallServiceGet()
        {
            EnsureNewCorrelationId();

            Logger.LogInformation("Calling Service1 from Blazor application");
            await Service1.GetAsync();
            Logger.LogInformation("Called Service1 from Blazor application");
        }

        protected async Task CallServicePost()
        {
            EnsureNewCorrelationId();

            Logger.LogInformation("POSTING to Service1 from Blazor application");
            await Service1.PostAsync(new StringContent(string.Empty));
            Logger.LogInformation("POSTED to Service1 from Blazor application");
        }
    }
}
