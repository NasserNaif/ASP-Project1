using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNames()
        {
            var names = new List<string> { "Alice", "Bob", "Charlie", "Diana" };
            return Ok(names);
        }
    }
}
