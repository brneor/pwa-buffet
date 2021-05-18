using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public int Id { get; set; }
        [ForeignKey("TipoCliente")]
        public string TipoClienteId { get; set; }
        public virtual TipoClienteEntity TipoCliente { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Observacoes { get; set; }
        [InverseProperty("Cliente")]
        public List<EventoEntity> Eventos { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}