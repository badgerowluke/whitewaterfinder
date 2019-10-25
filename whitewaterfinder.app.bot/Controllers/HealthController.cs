using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;

namespace whitewaterfinder.app.bot
{
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("I'm here");
        }
        [HttpPost]
        public IActionResult PostHealthCheck()
        {
            return Ok("Up and healthy");
        }
    }
}