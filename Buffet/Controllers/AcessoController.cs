using System;
using Buffet.Models.Acesso;
using Buffet.RequestModel;
using Buffet.ViewModels.Acesso;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class AcessoController : Controller
    {
        public readonly AcessoService _acessoService;

        public AcessoController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();

            viewModel.Mensagem = (string) TempData["errLogin"];
            
            return View(viewModel);
        }

        [HttpPost]
        public RedirectResult Login(AcessoLoginRequestModel request)
        {
            var redirectUrl = "/Acesso/Login";

            var email = request.UserEmail;
            var senha = request.UserPasswd;

            if (email == null || senha == null)
            {
                TempData["errLogin"] = "É necessário preencher email e senha!";
                return Redirect(redirectUrl);
            }
            
            return Redirect(redirectUrl);
        }
        
        public IActionResult ForgotPassword()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateAccount()
        {
            var viewModel = new LoginViewModel();

            viewModel.Mensagem = (string) TempData["errCadastro"];
            
            return View(viewModel);
        }
        
        [HttpPost]
        public RedirectResult CreateAccount(AcessoLoginRequestModel request)
        {
            var redirectUrl = "/Acesso/CreateAccount";

            var email = request.UserEmail;
            var senha = request.UserPasswd;

            if (email == null || senha == null)
            {
                TempData["errCadastro"] = "É necessário preencher email e senha!";
                return Redirect(redirectUrl);
            }

            try
            {
                _acessoService.CriarUsuario(email, senha);
                return Redirect("/Acesso/Login");
            }
            catch (Exception exception)
            {
                TempData["errCadastro"] = exception.Message;
            }
            
            return Redirect(redirectUrl);
        }
    }
}