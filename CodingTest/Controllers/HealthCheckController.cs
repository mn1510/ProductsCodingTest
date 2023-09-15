using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("")]
    public class HealthCheckController : ControllerBase
    {

        public HealthCheckController()
        {
        }

        [HttpGet(Name = "HealthCheck")]
        public IActionResult Get()
        {
            var healthData = new
            {
                Status = "OK",
                // Add more health checks as needed
            };

            return Ok(healthData);
        }
    }
}