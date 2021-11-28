using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.RootControllers;

namespace STS.Api.Controllers
{
    public class ExampleController : RootController
    {
        public ExampleController(
            ILogger<RootController> logger
        ) : base(logger)
        {
        }

        [HttpGet("logger")]
        public async Task<IActionResult> ExampleLogger()
        {
            _logger.LogInformation("Log information");
            _logger.LogDebug("Log debug");
            _logger.LogTrace("Log trace");
            _logger.LogWarning("Log watning");
            _logger.LogError("Log error");
            _logger.LogCritical("Log critical");

            return Ok();
        }
    }
}