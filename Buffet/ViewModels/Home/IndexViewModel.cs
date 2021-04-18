using System.Collections.Generic;

namespace Buffet.ViewModels.Home
{
    public class IndexViewModel
    {
        public ICollection<Cliente> clientes { get; set; }

        public IndexViewModel()
        {
            clientes = new List<Cliente>();
        }
    }

    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}