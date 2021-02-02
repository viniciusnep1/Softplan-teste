using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class InterestRateController : ControllerBase
    {
        private readonly ILogger<InterestRateController> _logger;

        public InterestRateController(ILogger<InterestRateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => await Task.FromResult(Ok(new { InterestRate = 0.01 }));
    }
}
