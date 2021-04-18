using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Buffet.Cliente;
using Buffet.ViewModels.Home;

namespace Buffet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClienteService _clienteService;
        // private readonly DatabaseContext _databaseContext;

        public HomeController(
            ILogger<HomeController> logger, 
            // DatabaseContext databaseContext
            ClienteService clienteService
            )
        {
            _logger = logger;
            // _databaseContext = databaseContext;
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            // var novoCliente = new ClienteEntity
            // {
            //     Nome = "Breno",
            //     DataNascimento = new DateTime(),
            //     Idade = 28
            // };
            // _databaseContext.Clientes.Add(novoCliente);
            // _databaseContext.SaveChanges();
            // var todosClientes = _databaseContext.Clientes.ToList();

            var viewmodel = new IndexViewModel();
            // Trazer lista de clientes do banco de dados.
            var clientesDoBanco = _clienteService.ObterClientes();

            foreach (var cliente in clientesDoBanco)
            {
                viewmodel.clientes.Add(new Cliente ()
                {
                    Id = cliente.Id.ToString(),
                    Nome = cliente.Nome
                });
            }
            

            
            return View(viewmodel);
        }

        // public IActionResult Login()
        // {
        //     return View();
        // }
        
        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Eula()
        {
            return View();
        }
        
        // public IActionResult ForgotPassword()
        // {
        //     return View();
        // }
        //
        // public IActionResult CreateAccount()
        // {
        //     return View();
        // }

        // public IActionResult Clientes()
        // {
        //     var clienteService = new ClienteService();
        //     var listaDeClientes = clienteService.obterClientes();
        //
        //     var viewModel = new ClientesViewModel();
        //     foreach (ClienteEntity clienteEntity in listaDeClientes)
        //     {
        //         viewModel.Clientes.Add(new Cliente
        //         {
        //             Nome = clienteEntity.Nome,
        //             DataDeNascimento = clienteEntity.DataNascimento.ToString()
        //         });
        //     }
        //     return View(viewModel);
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
    }
}