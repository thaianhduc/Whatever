using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Whatever.EventLike.Application;

namespace Whatever.EventLike.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountersController : ControllerBase
    {
        private readonly CountersService _service;

        public CountersController(CountersService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("/increase")]
        public async Task<IActionResult> Increase()
        {
            await _service.IncreaseCounter();
            return Ok("Have a good day!");
        }
    }
}