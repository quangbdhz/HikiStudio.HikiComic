using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [Route("403")]
        public IActionResult PageForbidden()
        {
            return View();
        }
    }
}
