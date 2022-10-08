using MCS.Dapr.POC.Backend.Calculator.Meters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace MCS.Dapr.POC.Backend.Calculator.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ArithmeticController : ControllerBase
    {
        private readonly ILogger<ArithmeticController> _logger;

        public ArithmeticController(ILogger<ArithmeticController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost(Name = "Addition")]
        public long Addition(long addend, long summand)
        {
            long result = addend + summand;

            _logger.LogInformation($"{addend} + {summand} = {result}");
            MeterHelper.ComputedResult.Add(result, new("name", nameof(Addition)), new("tools", nameof(ArithmeticController)));

            return result;
        }
    }
}