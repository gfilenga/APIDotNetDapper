using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public object Get()
        {
            return new { version = "HelloWorld" };
        }
    }
}