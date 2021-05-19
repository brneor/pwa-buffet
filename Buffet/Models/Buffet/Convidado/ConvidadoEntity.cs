using System;
using System.ComponentModel.DataAnnotations.Schema;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Models.Buffet.Convidado
{
    public class ConvidadoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public EventoEntity Evento { get; set; }
        public SituacaoConvidadoEntity SituacaoConvidado { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}