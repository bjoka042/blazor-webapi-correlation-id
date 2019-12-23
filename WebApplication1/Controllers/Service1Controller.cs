using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Proxy;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service1Controller : ControllerBase
    {
        private readonly IService2 _service2;
        private readonly ILogger<Service1Controller> _logger;

        public Service1Controller(
            IService2 service2,
            ILogger<Service1Controller> logger)
        {
            _service2 = service2;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation($"Entered {nameof(Service1Controller)}:{nameof(Get)}");

            _logger.LogInformation("Calling Service2 from Service1");
            await _service2.GetAsync();           
            _logger.LogInformation("Called Service2 from Service1");

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            _logger.LogInformation($"Entered {nameof(Service1Controller)}:{nameof(Post)}");

            _logger.LogInformation("Calling Service2 from Service1");
            await _service2.PostAsync(new StringContent(string.Empty));
            _logger.LogInformation("Called Service2 from Service1");

            return Ok();
        }
    }
}
