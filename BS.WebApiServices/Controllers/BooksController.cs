using BS.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _service;
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="service">Book service.</param>
        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok();
    }
}
