using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            viewModel.Mensagem = (string) TempData["msg-login"];
            
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
                TempData["msg-login"] = "É necessário preencher email e senha!";
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
            var viewModel = new CreateAccountViewModel();

            viewModel.Mensagem = (string) TempData["msg-cadastro"];
            viewModel.ErrosCadastro = (string[]) TempData["erros-cadastro"];
            
            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<RedirectToActionResult> CreateAccount(AcessoLoginRequestModel request)
        {
            var email = request.UserEmail;
            var senha = request.UserPasswd;

            if (email == null || senha == null)
            {
                TempData["msg-cadastro"] = "É necessário preencher email e senha!";
                return RedirectToAction("CreateAccount");
            }

            try
            {
                await _acessoService.CriarUsuario(email, senha);
                TempData["msg-login"] = "Cadastro realizado com sucesso";
                return RedirectToAction("Login");
            }
            catch (CadastrarUsuarioException exception)
            {
                var listaErros = new List<String>();
                foreach (var identityError in exception.Erros)
                {
                    listaErros.Add(identityError.Description);
                }
                TempData["erros-cadastro"] = listaErros;
            }
            
            return RedirectToAction("CreateAccount");
        }
    }
}