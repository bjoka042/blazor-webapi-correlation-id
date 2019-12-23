using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service2Controller : ControllerBase
    {
        private readonly ILogger<Service2Controller> _logger;

        public Service2Controller(ILogger<Service2Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"Entered {nameof(Service2Controller)}:{nameof(Get)}");
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            _logger.LogInformation($"Entered {nameof(Service2Controller)}:{nameof(Post)}");
            return Ok();
        }
    }
}
