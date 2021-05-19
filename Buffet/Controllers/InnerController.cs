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
        private readonly AcessoService _acessoService;

        public InnerController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        public IActionResult Start()
        {
            return View();
        }

        public IActionResult User()
        {
            var user = _acessoService.GetUser();
            return View(user);
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}