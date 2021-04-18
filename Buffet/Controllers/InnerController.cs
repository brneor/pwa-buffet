using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class InnerController : Controller
    {
        public IActionResult Start()
        {
            return View();
        }

        public new IActionResult User()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}