using System;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Acesso
{
    public class AcessoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly DatabaseContext _databaseContext;

        public AcessoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, DatabaseContext databaseContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _databaseContext = databaseContext;
        }

        public async Task CriarUsuario(string email, string senha)
        {
            var novoUsuario = new Usuario()
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(novoUsuario, senha);

            if (!resultado.Succeeded)
            {
                throw new CadastrarUsuarioException(resultado.Errors);
            }
            
        }

        public async Task Login(string email, string senha)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, senha, false, false);
            
            if (!resultado.Succeeded)
            {
                throw new Exception("Usuário ou senha inválidos!");
            }
        }

        public Usuario GetUser()
        {
            var userId = _signInManager.UserManager.GetUserId(_signInManager.Context.User);
            return _databaseContext.Users.Find(Guid.Parse(userId));
        }
    }
}