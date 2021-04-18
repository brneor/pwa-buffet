using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Acesso
{
    public class AcessoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AcessoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void CriarUsuario(string email, string senha)
        {
            var novoUsuario = new Usuario()
            {
                UserName = email,
                Email = email
            };

            var resultado = _userManager.CreateAsync(novoUsuario, senha);
            
        }

        // public void Login()
        // {
        //     
        // }
    }
}