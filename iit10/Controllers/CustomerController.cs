using Microsoft.AspNetCore.Mvc;

namespace iit10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
        }

        [HttpGet("index")]
        public ActionResult<string> Index()
        {
            return "haha got you, no customers in this app";
        }

    }
}
