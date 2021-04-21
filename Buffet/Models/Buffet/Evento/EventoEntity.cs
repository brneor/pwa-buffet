using System;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Local;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public int Id { get; set; }
        public TipoEventoEntity TipoEvento { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public ClienteEntity Cliente { get; set; }
        public SituacaoEventoEntity SituacaoEvento { get; set; }
        public LocalEntity Local { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}