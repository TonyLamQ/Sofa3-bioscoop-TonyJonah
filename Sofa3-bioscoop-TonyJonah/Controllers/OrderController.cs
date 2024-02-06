using Microsoft.AspNetCore.Mvc;

namespace Sofa3_bioscoop_TonyJonah.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet(Name = "test")]
        public void Get()
        {
        }
    }
}
