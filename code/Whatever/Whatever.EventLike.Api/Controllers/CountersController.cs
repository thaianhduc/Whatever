using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Whatever.EventLike.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountersController : ControllerBase
    {
        [HttpPost]
        [Route("/increase")]
        public async Task<IActionResult> Increase()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}