using System;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public int Id { get; set; }
        public TipoClienteEntity TipoCliente { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}