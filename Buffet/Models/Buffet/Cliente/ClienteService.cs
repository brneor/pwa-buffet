using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteService
    {
        public List<ClienteEntity> obterClientes()
        {
            var listaDeClientes = new List<ClienteEntity>();
         
            listaDeClientes.Add(new ClienteEntity
            {
                Id = 1,
                Nome = "Breno",
                DataNascimento = new DateTime(1992, 6, 30)
            });
            listaDeClientes.Add(new ClienteEntity
            {
                Id = 2,
                Nome = "José",
                DataNascimento = new DateTime(1987, 2, 21)
            });
            
            return listaDeClientes;
        }
    }
}