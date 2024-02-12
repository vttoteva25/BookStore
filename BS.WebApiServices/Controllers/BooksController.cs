using Microsoft.AspNetCore.Mvc;

namespace BS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}
