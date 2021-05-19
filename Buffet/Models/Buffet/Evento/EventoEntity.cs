using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Convidado;
using Buffet.Models.Buffet.Local;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public int Id { get; set; }
        [ForeignKey("TipoEvento")]
        public string TipoEventoId { get; set; }
        public TipoEventoEntity TipoEvento { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public ClienteEntity Cliente { get; set; }
        [ForeignKey("SituacaoEvento")]
        public string SituacaoEventoId { get; set; }
        public SituacaoEventoEntity SituacaoEvento { get; set; }
        [ForeignKey("Local")]
        public int LocalEntityId { get; set; }
        public LocalEntity Local { get; set; }
        [InverseProperty("Evento")]
        public List<ConvidadoEntity> Convidados { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}