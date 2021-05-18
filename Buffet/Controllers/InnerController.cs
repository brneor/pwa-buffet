using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models.Acesso;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class InnerController : Controller
    {
        private readonly DatabaseContext _context;

        public IActionResult Start()
        {
            return View();
        }

        public async Task<IActionResult> User()
        {
            var login = HttpContext.User.Identity.Name;
            // var user = _context.Users.Where(u => u.UserName.Equals(login));
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}