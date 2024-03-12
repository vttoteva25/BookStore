using Microsoft.AspNetCore.Mvc;

namespace BS.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CustomersController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
