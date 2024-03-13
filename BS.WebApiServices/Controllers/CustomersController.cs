using BS.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CustomersController : Controller
    {

        private readonly ICustomerService _service;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="service">Author service.</param>
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok();
    }
}
